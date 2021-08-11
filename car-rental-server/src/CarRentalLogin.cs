using System;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;

namespace car_rental_server
{
	public class CarRentalLogin
	{
		public static void login(int num, string[] request_array, Socket handler)
		{
			if (request_array[1].Equals("VISITOR"))
			{
				// 游客不需要检查账号密码也要通过socket请求，
				// 一是为了确保已经产生了处理线程，二也是为了拓展性
				handler.Send(Encoding.ASCII.GetBytes("LOGIN_SUCCESS \r\n"));
			}
			else if (request_array[1].Equals("USER"))
			{
				string sql = "SELECT account, password FROM user";
				check_login(sql, request_array[2], request_array[3]);
			}
			else if (request_array[1].Equals("ADMINISTRATOR"))
			{
				string sql = "SELECT account, password FROM user";
				check_login(sql, request_array[2], request_array[3]);
			}
			else
			{
				handler.Send(Encoding.ASCII.GetBytes("OTHER_WRONG \r\n"));
			}
		}

		private static string check_login(string sql_str, string account, string password)
		{
			MySqlCommand cmd = new MySqlCommand(sql_str, CarRentalServer.conn_db);
			MySqlDataReader rdr = cmd.ExecuteReader();

			// while (rdr.Read())
			// {
			// 	Console.WriteLine(rdr[0] + " -- " + rdr[1]);
			// }
			// rdr.Close();
			return "";
		}
	}
}