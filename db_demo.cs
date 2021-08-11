using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace test_db
{
	class Program
	{
		private static void read_db(MySqlConnection conn)
		{
			string sql = "SELECT account, password FROM user";
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			MySqlDataReader rdr = cmd.ExecuteReader();

			while (rdr.Read())
			{
				Console.WriteLine(rdr[0] + " -- " + rdr[1]);
			}
			rdr.Close();
		}

		static void Main(string[] args)
		{
			String connetStr = "server=8.136.218.156;user=user;database=car_rental_db;port=3306;password=password";
			MySqlConnection conn = new MySqlConnection(connetStr);

			try
			{
				conn.Open();
				Console.WriteLine("open successfully");

				read_db(conn);
				Console.WriteLine("\n============================");

				string sql = "INSERT INTO user (account, password) VALUES ('hijk','789')";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				cmd.ExecuteNonQuery();

				// =======================================================

				sql = "SELECT COUNT(*) FROM user";
				cmd = new MySqlCommand(sql, conn);
				object result = cmd.ExecuteScalar();
				if (result != null)
				{
					int r = Convert.ToInt32(result);
					Console.WriteLine("Number of countries in the world database is: " + r);
				}

				read_db(conn);

			}
			catch (MySqlException ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}

			conn.Close();
		}
	}
}
