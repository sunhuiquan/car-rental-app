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
					File.Create(file_path).Close();

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
				data = "<" + System.DateTime.Now.ToString() + "> :\r\n" + data;
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

		const string user_message_path = "/tmp/CarRentalServer/";

		public static int get_user_message(Socket handler, string account)
		{
			try
			{
				string message_file = user_message_path + account + ".txt";
				if (!Directory.Exists("/tmp/CarRentalServer"))
					Directory.CreateDirectory("/tmp/CarRentalServer");
				if (!File.Exists(message_file))
					File.Create(message_file).Close();

				string str = "";
				using (StreamReader sr = new StreamReader(message_file))
				{
					string temp = null;
					while ((temp = sr.ReadLine()) != null)
						str += temp + "\r\n";
				}
				handler.Send(Encoding.UTF8.GetBytes(str));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return -1;
			}
			return 0;
		}

		public static int put_message_to_user(Socket handler, string account)
		{
			// PUT_MESSAGE_TO_USER ACCOUNT \r\n
			// (wait until accept a SUCCESS)
			// 传数据(textBox的行也是\r\n)
			// MESSAGE_END \r\n
			try
			{
				string path = user_message_path + account + ".txt";

				if (!Directory.Exists("/tmp/CarRentalServer"))
					Directory.CreateDirectory("/tmp/CarRentalServer");
				if (!File.Exists(path))
					File.Create(path).Close();

				handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));

				byte[] bytes = new Byte[1024];
				string data = null;
				while (true)
				{
					int bytesRec = handler.Receive(bytes);
					if (bytesRec == 0)
						break;

					data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
					if (data.IndexOf("MESSAGE_END \r\n") > -1)
						break;
				}
				if (data == null)
					return -1;

				data = data.Substring(0, data.IndexOf("MESSAGE_END \r\n"));
				data = "<" + System.DateTime.Now.ToString() + "> :\r\n" + data;
				FileStream fs = new FileStream(path, FileMode.Append);
				StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
				sw.Write(data);
				sw.Flush();
				sw.Close();
				fs.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return -1;
			}
			return 0;
		}

		const string admin_message_path = "/tmp/CarRentalServer/admin.txt";

		public static int put_message_to_admin(Socket handler, string account)
		{
			// PUT_MESSAGE_TO_ADMIN ACCOUNT \r\n
			// (wait until accept a SUCCESS)
			// 传数据(textBox的行也是\r\n)
			// MESSAGE_END \r\n

			try
			{
				if (!Directory.Exists("/tmp/CarRentalServer"))
					Directory.CreateDirectory("/tmp/CarRentalServer");
				if (!File.Exists(admin_message_path))
					File.Create(admin_message_path).Close();

				handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));

				byte[] bytes = new Byte[1024];
				string data = null;
				while (true)
				{
					int bytesRec = handler.Receive(bytes);
					if (bytesRec == 0)
						break;

					data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
					if (data.IndexOf("MESSAGE_END \r\n") > -1)
						break;
				}
				if (data == null)
					return -1;

				data = data.Substring(0, data.IndexOf("MESSAGE_END \r\n"));
				data = "From " + account + " <" + System.DateTime.Now.ToString() + "> :\r\n" + data + "\r\n";
				FileStream fs = new FileStream(admin_message_path, FileMode.Append);
				StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
				sw.Flush();
				sw.Close();
				fs.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return -1;
			}
			return 0;
		}

		public static int get_admin_message(Socket handler)
		{
			try
			{
				if (!Directory.Exists("/tmp/CarRentalServer"))
					Directory.CreateDirectory("/tmp/CarRentalServer");
				if (!File.Exists(admin_message_path))
					File.Create(admin_message_path).Close();

				string str = "";
				using (StreamReader sr = new StreamReader(admin_message_path))
				{
					string temp = null;
					while ((temp = sr.ReadLine()) != null)
						str += temp + "\r\n";
				}
				handler.Send(Encoding.UTF8.GetBytes(str));
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