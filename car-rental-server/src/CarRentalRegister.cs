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
		private static long count = 0;
		private const string FILE_PATH = "/tmp/server_pic/pic_"; // 在linux的/tmp这是因为肯定存在且有权限

		public static int register(Socket handler, string[] args)
		{
			if (count < 0) // 溢出
				return -1;
			string pic_filepath = FILE_PATH + count.ToString() + ".png";

			byte[] b = new byte[4096];
			//如何确定该数组大小
			MemoryStream fs = new MemoryStream();
			int length = 0;
			//每次只能读取小于等于缓冲区的大小
			while ((length = handler.Receive(b)) > 0)
			{
				string request = Encoding.ASCII.GetString(b, 0, length);
				if (request.IndexOf("\r\n") > -1)
				{
					fs.Write(b, 0, length - 5); // 少读" \r\n"这五个字节
					break;
				}
				fs.Write(b, 0, length);
			}
			fs.Flush();
			Bitmap Img = new Bitmap(fs);
			Img.Save(pic_filepath, ImageFormat.Png);
			fs.Close();

			try
			{
				string sql = "INSERT INTO unsure_user(account, password, phone, pic_filepath, score, username) VALUES("
				+ args[1] + "," + args[2] + "," + args[4] + "," + pic_filepath + ",0," + args[3] + ");";
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