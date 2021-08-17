using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;

namespace car_rental_server
{
	public class CarRentalMessage
	{
		private const string file_path = "/tmp/CarRentalServer/announcement.txt";
		public static int annouce(Socket handler)
		{
			// ANNOUNCE \r\n
			// 传数据(textBox的行也是\r\n)
			// ANNOUNCE_END \r\n
			try
			{
				if (!Directory.Exists("/tmp/CarRentalServer"))
					Directory.CreateDirectory("/tmp/CarRentalServer");
				if (!File.Exists(file_path))
					File.Create(file_path);

				handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));

				byte[] bytes = new Byte[1024];
				string data = null;
				while (true)
				{
					int bytesRec = handler.Receive(bytes);
					if (bytesRec == 0)
						break;

					data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
					if (data.IndexOf("ANNOUNCE_END \r\n") > -1)
						break;
				}
				if (data == null)
					return -1;

				data = data.Substring(0, data.IndexOf("ANNOUNCE_END \r\n"));
				using (StreamWriter sw = new StreamWriter(file_path))
					sw.Write(data);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return -1;
			}
			return 0;
		}

		public static int get_annouce(Socket handler)
		{
			try
			{
				if (!File.Exists(file_path))
					return -1;

				string str = "";
				using (StreamReader sr = new StreamReader(file_path))
				{
					string temp = null;
					while ((temp = sr.ReadLine()) != null)
					{
						str += temp + "\r\n";
					}
				}

				handler.Send(Encoding.UTF8.GetBytes(str + "\r\n"));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return -1;
			}
			return 0;
		}
	}
}