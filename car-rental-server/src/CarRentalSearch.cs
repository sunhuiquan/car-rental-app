using System;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;

namespace car_rental_server
{
	public class CarRentalSearch
	{
		public static int list_all_parking_information(Socket handler)
		{
			try
			{
				string sql = "SELECT location,price,free_time,free_time_end,id,has_ordered FROM parking";
				MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				MySqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) // 一行一行地读
				{
					handler.Send(Encoding.UTF8.GetBytes(
						rdr[0] + " " + rdr[1] + " " + rdr[2] + " " + rdr[3] + " " + rdr[4] + " " + rdr[5] + "|"));
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

		public static int search_parking_information(Socket handler, string[] args)
		{
			try
			{
				string sql = null;
				// SEARCH LOCATION TIME_START DAYS PRICE \r\n
				string where_str = "";
				int i = 0;
				string[] temps = new string[4];

				if (!args[1].Equals("NULL"))
				{
					temps[i++] = "location like '%" + args[1] + "%'";
				}
				if (!args[2].Equals("NULL"))
				{
					temps[i++] = "free_time <= '" + args[2] + "' and free_time_end >= '" + args[2] + "'";
				}
				if (!args[3].Equals("NULL"))
				{
					temps[i++] = "free_time_end - free_time >= " + args[3];
				}
				if (!args[4].Equals("NULL"))
				{
					temps[i++] = "price <= " + args[4];
				}

				for (int j = 0; j < i; ++j)
				{
					if (j != i - 1)
						where_str += temps[j] + " and ";
					else
						where_str += temps[j];
				}


				if (where_str.Length == 0)
				{
					sql = "SELECT location,price,free_time,free_time_end,id,has_ordered FROM parking";
				}
				else
				{
					sql = "SELECT location,price,free_time,free_time_end,id,has_ordered FROM parking WHERE " + where_str;
				}
				MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				MySqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read()) // 一行一行地读
				{
					handler.Send(Encoding.UTF8.GetBytes(
						rdr[0] + " " + rdr[1] + " " + rdr[2] + " " + rdr[3] + " " + rdr[4] + " " + rdr[5] + "|"));
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