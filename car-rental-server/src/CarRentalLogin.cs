using System;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;

namespace car_rental_server
{
	public class CarRentalLogin
	{
		public static int login(int num, string[] request_array, Socket handler)
		{
			if (num >= 2)
			{
				if (request_array[1].Equals("VISITOR"))
				{
					// 游客不需要检查账号密码也要通过socket请求，
					// 一是为了确保已经产生了处理线程，二也是为了拓展性
					handler.Send(Encoding.ASCII.GetBytes("LOGIN_SUCCESS \r\n"));
					return 0;
				}
				else if (request_array[1].Equals("USER"))
				{
					string sql = "SELECT account, password FROM user";
					MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
					// MySqlDataReader rdr = cmd.ExecuteReader();

					// while (rdr.Read())
					// {
					// 	Console.WriteLine(rdr[0] + " -- " + rdr[1]);
					// }
					// rdr.Close();
					return -1;
				}
				else if (request_array[1].Equals("ADMINISTRATOR"))
				{
					return -1;
					// to do
				}
				else
				{
					handler.Send(Encoding.ASCII.GetBytes("OTHER_WRONG \r\n"));
					return -1;
				}
			}
			else
			{
				handler.Send(Encoding.ASCII.GetBytes("OTHER_WRONG \r\n"));
				return -1;
			}
		}
	}
}