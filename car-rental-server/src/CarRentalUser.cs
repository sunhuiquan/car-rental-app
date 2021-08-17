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

		public static int list_all_order_information(Socket handler)
		{
			try
			{
				string sql = "SELECT user_account, parking_id, date_start, date_end, cost FROM order_form";
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

		public static int ban_user(Socket handler, string account)
		{
			try
			{
				string sql = "DELETE FROM user WHERE account='" + account + "';";
				MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				cmd.ExecuteNonQuery();

				sql = "UPDATE parking SET has_ordered=0 WHERE id in (SELECT id FROM order_form WHERE account='"
						+ account + "');";
				cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				cmd.ExecuteNonQuery();

				sql = "DELETE FROM order_form WHERE user_account='" + account + "';";
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

		public static int ban_parking(Socket handler, string id)
		{
			try
			{
				bool has_ordered = false;
				string sql = "SELECT has_ordered FROM parking WHERE id='" + id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				MySqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					if (int.Parse(rdr[0].ToString()) != 0)
						has_ordered = true;
				}
				rdr.Close();

				int cost = 0;
				string account = null;
				if (has_ordered)
				{
					sql = "SELECT user_account,cost FROM order_form WHERE parking_id='" + id + "';";
					cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
					rdr = cmd.ExecuteReader();
					if (rdr.Read())
					{
						account = rdr[0].ToString();
						cost = int.Parse(rdr[1].ToString());
					}
					rdr.Close();

					sql = "DELETE FROM order_form WHERE parking_id='" + id + "';";
					cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
					cmd.ExecuteNonQuery();
				}

				sql = "DELETE FROM parking WHERE id='" + id + "';";
				cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				cmd.ExecuteNonQuery();

				if (has_ordered)
				{
					sql = "UPDATE user SET money=money+" + cost.ToString() + " WHERE account='" + account + "';";
					cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
					cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return -1;
			}
			return 0;
		}

		public static int ban_order(Socket handler, string account, string id)
		{
			try
			{
				int cost = 0;
				string sql = "SELECT cost FROM order_form WHERE user_account='" + account + "' and parking_id='" + id + "';";
				MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				MySqlDataReader rdr = cmd.ExecuteReader();
				if (rdr.Read()) // 一行一行地读
					cost = int.Parse(rdr[0].ToString());
				rdr.Close();

				sql = "DELETE FROM order_form WHERE user_account='" + account + "' and parking_id='" + id + "';";
				cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				cmd.ExecuteNonQuery();

				sql = "UPDATE parking SET has_ordered=0 WHERE id='" + id + "';";
				cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				cmd.ExecuteNonQuery();

				sql = "UPDATE user SET money=money+" + cost.ToString() + " WHERE account='" + account + "';";
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
	}
}