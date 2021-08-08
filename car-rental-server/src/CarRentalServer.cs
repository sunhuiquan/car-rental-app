using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace car_rental_server
{
	public class CarRentalServer
	{
		private static Semaphore sem = new Semaphore(40, 40);
		public static void StartListening()
		{
			IPAddress ipAddress = IPAddress.Parse("0.0.0.0"); // 监听所有网卡
			IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 50000);

			Socket listener = new Socket(ipAddress.AddressFamily,
				SocketType.Stream, ProtocolType.Tcp);

			try
			{
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
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		private static void thread_handler(Object obj)
		{
			Socket handler = (Socket)obj;
			string[] request_array = null;
			string request = receive_request(handler);
			int num = request_parse(request, request_array);

			// 登录功能（此功能必须第一个执行一次，其他功能顺序任意）
			if ((num < 1) || (request_array[0].Equals("ACCOUNT") == false) ||
			(CarRentalLogin.login(num, request_array, handler)) != 0)
			{
				end_server(handler);
				return;
			}

			// 循环执行其他请求功能
			while (true)
			{
				request = receive_request(handler);
				num = request_parse(request, request_array);
			}

			end_server(handler);
		}

		private static string receive_request(Socket handler)
		{
			byte[] bytes = new Byte[1024];
			string request = null;

			while (true)
			{
				int bytesRec = handler.Receive(bytes);
				request += Encoding.ASCII.GetString(bytes, 0, bytesRec);
				if (request.IndexOf("\r\n") > -1)
					break;
			}
			return request;
		}

		// 返回的是数组的Length
		private static int request_parse(string request, string[] request_array)
		{
			if (request != null)
				request_array = request.Split();
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
	}
}