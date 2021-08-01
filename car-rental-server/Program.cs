using System;

namespace car_rental_server
{
	class Program
	{
		public static int Main(string[] args)
		{
			CarRentalServer.StartListening();

			return 0;
		}
	}
}
