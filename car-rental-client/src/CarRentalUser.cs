using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental_client
{
    class CarRentalUser
    {
        public static string[] get_user_information(string account)
        {
            string[] user_information_array = null;

            // GET_USER ACCOUNT \r\n
            CarRentalClient.send("GET_USER " + account + " \r\n");

            // USER_INFORMATION ACCOUNT USERNAME SCORE MONEY \r\n
            int i = 0;
            string rec = CarRentalClient.receive(ref i);
            if (rec.Split(' ')[0].Equals("USER_INFORMATION"))
            {
                user_information_array = rec.Split(' ');
                return user_information_array;
            }
            return null;
        }
    }
}
