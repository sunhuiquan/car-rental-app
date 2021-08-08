using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace car_rental_server
{
	public class CarRentalLogin
	{
		// 游客不需要检查账号密码也要通过socket请求，
		// 一是为了确保已经产生了处理线程，二也是为了拓展性
		public static int login(int num, string[] request_array, Socket handler)
		{
			if (num >= 2)
			{
				if (request_array[1].Equals("VISITOR"))
				{
					handler.Send(Encoding.ASCII.GetBytes("LOGIN_SUCCESS \r\n"));
					return 0;
				}
				else if (request_array[1].Equals("USER"))
				{
					return -1;
					// to do
				}
				else if (request_array[1].Equals("ADMINISTRATOR"))
				{
					return -1;
					// to do
				}
				else
				{
					handler.Send(Encoding.ASCII.GetBytes("OTHER_WRONG \r\n"));
					return -1;
				}
			}
			else
			{
				handler.Send(Encoding.ASCII.GetBytes("OTHER_WRONG \r\n"));
				return -1;
			}
		}
	}
}