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
				string sql = "SELECT location,price,free_time,free_time_end,id FROM parking";
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