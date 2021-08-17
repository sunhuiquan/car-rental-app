using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using MySql.Data.MySqlClient;

namespace car_rental_server
{
	public class CarRentalServer
	{
		public static MySqlConnection conn_db;
		private static Semaphore sem = new Semaphore(40, 40);

		public static void start_server()
		{
			// 连接数据库
			if (connect_database() != 0)
			{
				return;
			}
			// 开始监听和多线程处理请求
			StartListening();
		}

		private static void StartListening()
		{
			IPAddress ipAddress = IPAddress.Parse("0.0.0.0"); // 监听所有网卡
			IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 50000);

			Socket listener = new Socket(ipAddress.AddressFamily,
				SocketType.Stream, ProtocolType.Tcp);

			listener.Bind(localEndPoint);
			listener.Listen(10); // 未决连接数

			while (true)
			{
				Socket handler = listener.Accept();
				Console.WriteLine("Connect from " + ((IPEndPoint)handler.RemoteEndPoint).Address.ToString());

				sem.WaitOne();
				Thread thr = new Thread(new ParameterizedThreadStart(thread_handler));
				thr.Start(handler);
			}
		}

		/* 注意数组类型和自定义类型都是引用类型，作为参数传递本质和c/c++的指针一样，
		 * 而不是和c++的引用一样。
		 * 本质来说还是值传递，实参是形参的副本，和指针一样(指针本身是副本)，而引用
		 * 只是一个别名，是同一个本体，没有副本，所以说c#/java的引用和指针本质才一样。
		 * 参数是一个副本变量，值是拷贝进来的值，而c#引用类型的值就是c指针的值(地址)
		 */
		private static void thread_handler(Object obj)
		{
			int is_closed = 0;
			Socket handler = (Socket)obj;
			string[] request_array = null;

			while (true)
			{
				string request = receive_request(handler, ref is_closed);
				if (is_closed == 1) // 因为对端关闭所以服务结束
					break;
				int num = request_parse(request, ref request_array);

				// 解析指令 /r/n必有，一个功能说明必有，至少是2
				if (num < 2)
				{
					handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
				}
				else
				{
					// 功能解析
					if (request_array[0].Equals("ACCOUNT"))
					{
						if (check_login_num(num, request_array) != 0 || CarRentalLogin.login(request_array, handler) != 0)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
					}
					else if (request_array[0].Equals("REGISTER"))
					{
						if (num != 6)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						else
						{
							if (CarRentalRegister.register(handler, request_array) == 0)
								handler.Send(Encoding.UTF8.GetBytes("REGISTER_SUCCESS \r\n"));
							else
								handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						}
					}
					else if (request_array[0].Equals("LIST"))
					{
						if (num != 2)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						else
						{
							if (CarRentalSearch.list_all_parking_information(handler) == 0)
								handler.Send(Encoding.UTF8.GetBytes("LIST_END \r\n"));
							else
								handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						}
					}
					else if (request_array[0].Equals("SEARCH"))
					{
						if (num != 6)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						else
						{
							if (CarRentalSearch.search_parking_information(handler, request_array) == 0)
								handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));
							else
								handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						}
					}
					else if (request_array[0].Equals("RENTAL"))
					{
						if (num != 6)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						else
						{
							if (CarRentalRealease.rent_realease(handler, request_array) == 0)
								handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));
							else
								handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						}
					}
					else if (request_array[0].Equals("CHARGE_MONEY"))
					{
						if (CarRentalUser.charge_money(handler, request_array) == 0)
							handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));
						else
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
					}
					else if (request_array[0].Equals("GET_USER"))
					{
						// GET_USER ACCOUNT \r\n
						if (num != 3)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						else if (CarRentalUser.get_user_information(handler, request_array) != 0)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
					}
					else if (request_array[0].Equals("LIST_USER"))
					{
						if (num != 2)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						else
						{
							if (CarRentalUser.list_all_user_information(handler) == 0)
								handler.Send(Encoding.UTF8.GetBytes("LIST_USER_END \r\n"));
							else
								handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						}
					}
					else if (request_array[0].Equals("LIST_ORDER"))
					{
						if (num != 2)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						else
						{
							if (CarRentalUser.list_all_order_information(handler) == 0)
								handler.Send(Encoding.UTF8.GetBytes("LIST_ORDER_END \r\n"));
							else
								handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						}
					}
					else if (request_array[0].Equals("BAN_USER"))
					{
						// BAN_USER ACCOUNT \r\n
						if (num != 3)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						else
						{
							if (CarRentalUser.ban_user(handler, request_array[1]) == 0)
								handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));
							else
								handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						}
					}
					else if (request_array[0].Equals("BAN_PARKING"))
					{
						// BAN_PARKING ID \r\n
						if (num != 3)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						else
						{
							if (CarRentalUser.ban_parking(handler, request_array[1]) == 0)
								handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));
							else
								handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						}
					}
					else if (request_array[0].Equals("BAN_ORDER"))
					{
						// BAN_ORDER ACCOUNT ID \r\n
						if (num != 4)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						else
						{
							if (CarRentalUser.ban_order(handler, request_array[1], request_array[2]) == 0)
								handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));
							else
								handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						}
					}
					else if (request_array[0].Equals("ORDER"))
					{
						// ORDER ACCOUNT ID TIME_START DAYS \r\n
						if (num != 6)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						else
						{
							order_type ret = CarRentalOrder.order(handler, request_array);
							if (ret == order_type.SUCCESS)
								handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));
							else if (ret == order_type.ID_OR_DATE_WRONG)
								handler.Send(Encoding.UTF8.GetBytes("ID_OR_DATE_WRONG \r\n"));
							else if (ret == order_type.MONEY_WRONG)
								handler.Send(Encoding.UTF8.GetBytes("MONEY_WRONG \r\n"));
							else if (ret == order_type.HAS_ORDERED_WRONG)
								handler.Send(Encoding.UTF8.GetBytes("HAS_ORDERED_WRONG \r\n"));
							else
								handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						}
					}
					else if (request_array[0].Equals("ANNOUNCE"))
					{
						if (num != 2)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						else
						{
							if (CarRentalMessage.annouce(handler) == 0)
								handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));
							else
								handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						}
					}
					else if (request_array[0].Equals("GET_ANNOUNCE"))
					{
						if (num != 2)
							handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						else
						{
							if (CarRentalMessage.get_annouce(handler) == 0)
								handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));
							else
								handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						}
					}
					// else if (request_array[0].Equals(""))
					// {}
					// else if (request_array[0].Equals(""))
					// {
					// 	/* 
					// 	eg 1:
					// 	string sql = "SELECT 查询语句";
					// 	MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
					// 	MySqlDataReader rdr = cmd.ExecuteReader();
					// 	while (rdr.Read()) // 一行一行地读
					// 	{
					// 		Console.WriteLine(rdr[0] + " -- " + rdr[1]);
					// 		// [0] [1] 分别对应第一列属性 第二列属性
					// 	}
					// 	rdr.Close();

					// 	eg 2:
					// 	string sql = "INSERT 非查询语句比如插入、删除之类";
					// 	MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
					// 	cmd.ExecuteNonQuery();
					// 	*/
					// }
					else
					{
						handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
						Console.WriteLine("aa");
					}
				}
			}
			end_server(handler);
		}

		private static int check_login_num(int num, string[] request_array)
		{
			if (request_array[1].Equals("VISITOR") && num < 3)
			{
				return -1;
			}
			else if ((request_array[1].Equals("USER") || request_array[1].Equals("ADMINISTER")) && num < 5)
			{
				return -1;
			}
			return 0;
		}

		private static string receive_request(Socket handler, ref int is_closed)
		{
			byte[] bytes = new Byte[1024];
			string request = null;

			while (true)
			{
				int bytesRec = handler.Receive(bytes);
				// 正常这样没有数据可读会阻塞，0说明对端套接字已经关闭，
				// 最重要的是关闭在 \r\n 之前说明这个指令不全，需要舍弃
				if (bytesRec == 0)
				{
					is_closed = 1;
					break;
				}
				request += Encoding.UTF8.GetString(bytes, 0, bytesRec);
				if (request.IndexOf("\r\n") > -1)
					break;
			}
			return request;
		}

		// 返回的是数组的Length
		private static int request_parse(string request, ref string[] request_array)
		{
			if (request != null)
				request_array = request.Split(' '); // 注意分割符默认不只有空格
			if (request_array != null) // null一解引用Length就会异常
				return request_array.Length;
			else
				return -1;
		}

		private static void end_server(Socket handler)
		{
			handler.Shutdown(SocketShutdown.Both);
			handler.Close();
			sem.Release();
		}
		private static int connect_database()
		{
			String connetStr = "server=8.136.218.156;user=user;database=db;port=3306;password=password";
			conn_db = new MySqlConnection(connetStr);
			try
			{
				conn_db.Open();
				Console.WriteLine("open successfully");
			}
			catch (MySqlException ex)
			{
				Console.WriteLine(ex.ToString());
				return -1;
			}
			return 0;
		}
	}
}