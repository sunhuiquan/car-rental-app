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

        public static string[] list_user_information()
        {
            CarRentalClient.send("LIST_USER \r\n");
            int is_closed = 0;
            int size = 16;
            string[] str_array = new string[size];

            string str = CarRentalClient.receive(ref is_closed);
            // 不断接受直到最后\r\n

            string[] line_array = str.Split('|');
            if (line_array[line_array.Length - 1].IndexOf("OTHER_WRONG") != -1)
                return null;

            for (int i = 0; ; ++i)
            {
                if (line_array[i].IndexOf("LIST_USER_END") != -1)
                    break;

                if (i == size - 1)
                {
                    string[] temp = new string[size * 2];
                    for (int j = 0; j < str_array.Length; ++j)
                        temp[j] = str_array[j];
                    str_array = temp;
                }
                str_array[i] = line_array[i];
            }
            return str_array;
        }

        public static string[] list_order_information()
        {
            CarRentalClient.send("LIST_ORDER \r\n");
            int is_closed = 0;
            int size = 16;
            string[] str_array = new string[size];

            string str = CarRentalClient.receive(ref is_closed);
            // 不断接受直到最后\r\n

            string[] line_array = str.Split('|');
            if (line_array[line_array.Length - 1].IndexOf("OTHER_WRONG") != -1)
                return null;

            for (int i = 0; ; ++i)
            {
                if (line_array[i].IndexOf("LIST_ORDER_END") != -1)
                    break;

                if (i == size - 1)
                {
                    string[] temp = new string[size * 2];
                    for (int j = 0; j < str_array.Length; ++j)
                        temp[j] = str_array[j];
                    str_array = temp;
                }
                str_array[i] = line_array[i];
            }
            return str_array;
        }
    }
}
