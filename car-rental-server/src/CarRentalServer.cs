using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace car_rental_server
{
	public class CarRentalServer
	{
		static Semaphore sem = new Semaphore(40,40);

		static void thread_handler(Object obj)
		{
			Socket handler = (Socket)obj;
			byte[] bytes = new Byte[1024];
			string data = null;

			while (true)
			{
				int bytesRec = handler.Receive(bytes);
				data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
				if (data.IndexOf("<EOF>") > -1)
					break;
			}

			Console.WriteLine("Text received : {0}", data);

			byte[] msg = Encoding.ASCII.GetBytes(data);
			handler.Send(msg);

			handler.Shutdown(SocketShutdown.Both);
			handler.Close();

			sem.Release();
		}

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
	}
}