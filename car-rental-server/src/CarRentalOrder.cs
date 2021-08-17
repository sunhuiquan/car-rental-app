using System;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;

namespace car_rental_server
{
	public enum order_type { SUCCESS, ID_OR_DATE_WRONG, MONEY_WRONG, HAS_ORDERED_WRONG, OTHER_WRONG }

	public class CarRentalOrder
	{
		public static order_type order(Socket handler, string[] args)
		{
			// ORDER ACCOUNT ID TIME_START DAYS \r\n
			try
			{
				bool has_this_park = false;
				int money_per_day = 0;
				string sql = "SELECT location,price,free_time,free_time_end,id,has_ordered FROM parking WHERE id='" +
				 args[2] + "' and free_time <= '" + args[3] + "' and free_time_end >= '" +
				 args[3] + "' + '" + args[4] + "' - '1'";
				MySqlCommand cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				MySqlDataReader rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{ // 因为id是主键,所以要么没有要么只有一个
					if (int.Parse(rdr[5].ToString()) != 0)
					{
						rdr.Close();
						return order_type.HAS_ORDERED_WRONG;
					}

					has_this_park = true;
					money_per_day = int.Parse(rdr[1].ToString());
				}
				rdr.Close();
				if (!has_this_park) // 没有满足条件的车位
					return order_type.ID_OR_DATE_WRONG;

				bool has_this_user = false;
				int cost = money_per_day * int.Parse(args[4]);
				sql = "SELECT money FROM user WHERE account='" + args[1] + "';"; ;
				cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				rdr = cmd.ExecuteReader();
				if (rdr.Read())
				{ // 因为id是主键,所以要么没有要么只有一个
					has_this_user = true;
					if (cost > int.Parse(rdr[0].ToString()))
					{
						rdr.Close();
						return order_type.MONEY_WRONG;
					}
				}
				rdr.Close();
				if (!has_this_user) // 没有满足条件的车位
					return order_type.OTHER_WRONG;

				// 注意要先插入再扣钱,不然会造成数据不一致(扣了钱但插入失败),
				// 而先插入失败自然就不用扣钱
				sql = "INSERT INTO order_form(user_account,parking_id,date_start,date_end,cost) VALUES ('" +
						args[1] + "','" + args[2] + "','" + args[3] + "',date_add('" + args[3] + "', interval " +
						(int.Parse(args[4]) - 1).ToString() + " day)," + cost.ToString() + ");";
				cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				cmd.ExecuteNonQuery();

				sql = "UPDATE parking SET has_ordered=1 WHERE id='" + args[2] + "';";
				cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				cmd.ExecuteNonQuery();

				sql = "UPDATE user SET money=money-" + cost.ToString() + " WHERE account='" + args[1] + "';";
				cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				cmd.ExecuteNonQuery();

				sql = "UPDATE user SET score=score+" + cost.ToString() + " WHERE account='" + args[1] + "';";
				// 花钱加积分
				cmd = new MySqlCommand(sql, CarRentalServer.conn_db);
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return order_type.OTHER_WRONG;
			}
			return order_type.SUCCESS;
		}
	}
}