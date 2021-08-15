using System;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;

namespace car_rental_server
{
	public class CarRentalLogin
	{
		public static int login(string[] request_array, Socket handler)
		{
			// 已经保证num数量正确了
			if (request_array[1].Equals("VISITOR"))
			{
				// 游客不需要检查账号密码也要通过socket请求，
				// 一是为了确保已经产生了处理线程，二也是为了拓展性
				handler.Send(Encoding.UTF8.GetBytes("LOGIN_SUCCESS \r\n"));
				return 0;
			}
			else if (request_array[1].Equals("USER"))
			{
				string sql = "SELECT account, password FROM user";
				string result = check_login(sql, request_array[2], request_array[3]);
				handler.Send(Encoding.UTF8.GetBytes(result));

				if (result.Equals("LOGIN_SUCCESS \r\n"))
					return 0;
				return -1;
			}
			else if (request_array[1].Equals("ADMINISTRATOR"))
			{
				string sql = "SELECT account, password FROM administer";
				string result = check_login(sql, request_array[2], request_array[3]);
				handler.Send(Encoding.UTF8.GetBytes(result));

				if (result.Equals("LOGIN_SUCCESS \r\n"))
					return 0;
				return -1;
			}
			else
			{
				handler.Send(Encoding.UTF8.GetBytes("OTHER_WRONG \r\n"));
				return -1;
			}
		}

		private static string check_login(string sql_str, string account, string password)
		{
			MySqlCommand cmd = new MySqlCommand(sql_str, CarRentalServer.conn_db);
			MySqlDataReader rdr = cmd.ExecuteReader();
			while (rdr.Read())
			{
				if (account.Equals(rdr[0]))
				{
					if (password.Equals(rdr[1]))
					{
						rdr.Close();
						return "LOGIN_SUCCESS \r\n";
					}
					else
					{
						rdr.Close();
						return "PASSWORD_WRONG \r\n";
					}
				}
			}
			rdr.Close();
			return "ACCOUNT_NOT_FOUND \r\n";
		}
	}
}