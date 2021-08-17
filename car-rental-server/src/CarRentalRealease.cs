using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;


namespace car_rental_server
{
	public class CarRentalRealease
	{
		public static int id = 0;
		public static bool is_first_time = true;
		public static int rent_realease(Socket handler, string[] args)
		{
			// RENTAL LOCATION TIME_START TIME_END PRICE \r\n
			try
			{
				if (is_first_time)
				{
					// to get a right id
					string sql1 = "SELECT id from parking;";
					MySqlCommand cmd1 = new MySqlCommand(sql1, CarRentalServer.conn_db);
					MySqlDataReader rdr = cmd1.ExecuteReader();
					while (rdr.Read()) // 一行一行地读
					{
						if (int.Parse(rdr[0].ToString()) >= id)
							id = int.Parse(rdr[0].ToString()) + 1;
					}
					rdr.Close();
				}

				string sql = "INSERT INTO parking(location, free_time, free_time_end, price, id,has_ordered) VALUES('"
						  + args[1] + "','" + args[2] + "','" + args[3] + "'," + args[4] + ",'" + id.ToString() + "',0);";
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