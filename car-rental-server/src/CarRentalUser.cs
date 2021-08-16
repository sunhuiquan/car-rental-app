using System;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;

namespace car_rental_server
{
	public class CarRentalUser
	{
		public static int charge_money(Socket handler, string[] args)
		{
			// CHARGE_MONEY ACCOUNT VALUE \r\n
			if (args.Length != 4)
				return -1;

			try
			{
				// UPDATE table_name SET field1=new-value1, field2=new-value2
				string sql = "UPDATE user SET money=money+" + args[2] + " WHERE account='" + args[1] + "';";
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

		public static int get_user_information(Socket handler, string[] args)
		{
			// GET_USER ACCOUNT \r\n
			try
			{
				bool find_user = false;
				string sql = "SELECT account,username,score,money FROM user WHERE account='" + args[1] + "';";
				MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				MySqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) // 一行一行地读
				{
					// USER_INFORMATION ACCOUNT USERNAME SCORE MONEY \r\n
					handler.Send(Encoding.UTF8.GetBytes("USER_INFORMATION " + rdr[0] + " " + rdr[1] + " " + rdr[2] + " " + rdr[3] + " \r\n"));
					find_user = true;
					break;
				}
				rdr.Close();

				if (!find_user)
					return -1;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return -1;
			}
			return 0;
		}

		public static int list_all_user_information(Socket handler)
		{
			try
			{
				string sql = "SELECT account, username, phone, money, score FROM user";
				MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				MySqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) // 一行一行地读
				{
					handler.Send(Encoding.UTF8.GetBytes(
						rdr[0] + " " + rdr[1] + " " + rdr[2] + " " + rdr[3] + " " + rdr[4] + "|"));
				}
				rdr.Close();
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