using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;


namespace car_rental_server
{
	public class CarRentalRegister
	{
		private const string FILE_PATH = "/tmp/server_pic/pic_"; // 在linux的/tmp这是因为肯定存在且有权限

		public static int register(Socket handler, string[] args)
		{
			try
			{
				handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));
				string pic_filepath = FILE_PATH + args[1] + ".png";

				if (!Directory.Exists("/tmp/server_pic"))
					Directory.CreateDirectory("/tmp/server_pic");
				if (!File.Exists(pic_filepath))
					File.Create(pic_filepath).Close();

				byte[] bytes = new Byte[1024];
				string request = null;
				while (true)
				{
					int bytesRec = handler.Receive(bytes);
					request += Encoding.UTF8.GetString(bytes, 0, bytesRec);
					if (request.IndexOf("\r\n") > -1)
						break;
				}
				long length = long.Parse(request.Split(' ')[0]);
				handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));

				byte[] b = new byte[length + 100];
				if (handler.Receive(b) != length)
					return -1;

				// 截断模式+账号不可能重复保证正确性
				BinaryWriter bw = new BinaryWriter(new FileStream(pic_filepath, FileMode.Truncate));
				bw.Write(b, 0, int.Parse(length.ToString()));
				bw.Close();

				string sql = "INSERT INTO unsure_user(account, password, phone, pic_filepath, score, username, money) VALUES('"
				+ args[1] + "','" + args[2] + "','" + args[4] + "','" + pic_filepath + "',0,'" + args[3] + "',0);";
				MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return -1;
			}
			return 0;
		}

		public static void get_unsure_user(Socket handler)
		{
			try
			{
				string sql = "SELECT account,username,phone,pic_pathname from unsure_user;";
				MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				MySqlDataReader rdr = cmd.ExecuteReader();
				bool has_next = false;
				string file_path = null;
				if (rdr.Read())
				{
					has_next = true;
					handler.Send(Encoding.UTF8.GetBytes("RESPONSE " + rdr[0] + " " + rdr[1] + " " + rdr[2] + " \r\n"));
					file_path = rdr[3].ToString();
				}
				rdr.Close();
				if (!has_next)
					handler.Send(Encoding.UTF8.GetBytes("EMPTY \r\n"));

				byte[] b = new Byte[1024];
				string request = null;
				while (true)
				{
					int bytesRec = handler.Receive(b);
					request += Encoding.UTF8.GetString(b, 0, bytesRec);
					if (request.IndexOf("\r\n") > -1)
						break;
				}
				if (!request.Split(' ')[0].Equals("SUCCESS"))
					handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));

				FileStream fileStream = new FileStream(file_path, FileMode.Open, FileAccess.Read);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				long length = fileStream.Length;
				byte[] bytes = new byte[length];
				binaryReader.Read(bytes, 0, bytes.Length);
				binaryReader.Close();
				handler.Send(Encoding.UTF8.GetBytes(length.ToString() + "\r\n"));

				b = new Byte[1024];
				request = null;
				while (true)
				{
					int bytesRec = handler.Receive(b);
					request += Encoding.UTF8.GetString(b, 0, bytesRec);
					if (request.IndexOf("\r\n") > -1)
						break;
				}
				if (!request.Split(' ')[0].Equals("SUCCESS"))
					handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));

				handler.Send(bytes);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
				return;
			}
		}
	}
}