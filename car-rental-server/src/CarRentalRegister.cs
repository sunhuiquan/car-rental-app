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
				// DateTime beforDT = System.DateTime.Now;

				handler.Send(Encoding.UTF8.GetBytes("SUCCESS \r\n"));
				string pic_filepath = FILE_PATH + args[1] + ".png";

				if (!Directory.Exists("/tmp/server_pic"))
					Directory.CreateDirectory("/tmp/server_pic");

				FileStream a = new FileStream(pic_filepath, FileMode.Create);
				a.Close();

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
				FileStream fs = new FileStream(pic_filepath, FileMode.Append);
				BinaryWriter bw = new BinaryWriter(fs);
				for (int l = 0; l < length;)
				{
					int len = handler.Receive(b);
					bw.Write(b, 0, len);
					l += len;
				}
				bw.Close();
				fs.Close();

				string sql = "INSERT INTO unsure_user(account, password, phone, pic_filepath, score, username, money) VALUES('"
				+ args[1] + "','" + args[2] + "','" + args[4] + "','" + pic_filepath + "',0,'" + args[3] + "',0);";
				MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				cmd.ExecuteNonQuery();

				// DateTime afterDT = System.DateTime.Now;
				// TimeSpan ts = afterDT.Subtract(beforDT);
				// Console.WriteLine("DateTime总共花费{0}ms.", ts.TotalMilliseconds);
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
				string sql = "SELECT account,username,phone,pic_filepath from unsure_user;";
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
				{
					handler.Send(Encoding.UTF8.GetBytes("EMPTY \r\n"));
					return;
				}

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
				{
					handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
					return;
				}

				FileStream fileStream = new FileStream(file_path, FileMode.Open, FileAccess.Read);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				long length = fileStream.Length;
				byte[] bytes = new byte[length];
				binaryReader.Read(bytes, 0, bytes.Length);
				binaryReader.Close();
				fileStream.Close();
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
				{
					handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
					return;
				}

				handler.Send(bytes);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
				return;
			}
		}

		public static int register_approve(Socket handler, string account)
		{
			// REGISTER_APPROVE ACCOUNT \r\n
			try
			{
				string[] information = new string[7];
				string sql = "SELECT account, password, phone, pic_filepath, score, username," +
							"money FROM unsure_user WHERE account = '" + account + "'; ";
				MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				MySqlDataReader rdr = cmd.ExecuteReader();
				bool has_next = false;
				if (rdr.Read())
				{
					has_next = true;
					information[0] = rdr[0].ToString();
					information[1] = rdr[1].ToString();
					information[2] = rdr[2].ToString();
					information[3] = rdr[3].ToString();
					information[4] = rdr[4].ToString();
					information[5] = rdr[5].ToString();
					information[6] = rdr[6].ToString();
				}
				rdr.Close();
				if (!has_next)
					return -1;

				sql = "DELETE FROM unsure_user WHERE account='" + account + "';";
				cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				cmd.ExecuteNonQuery();

				sql = "INSERT INTO user(account, password, phone, pic_filepath, score, username, money) VALUES('"
				+ information[0] + "','" + information[1] + "','" + information[2] + "','" + information[3]
				+ "'," + information[4] + ",'" + information[5] + "'," + information[6] + ");";
				cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return -1;
			}
			return 0;
		}

		public static int register_fail(Socket handler, string account)
		{
			// REGISTER_FAIL ACCOUNT \r\n
			try
			{
				string sql = "DELETE FROM unsure_user WHERE account='" + account + "';";
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
	}
}