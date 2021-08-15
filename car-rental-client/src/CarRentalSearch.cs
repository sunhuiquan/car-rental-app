using System;

namespace car_rental_client
{
    public class CarRentalSearch
    {
        public static string[] list_parking_information()
        {
            CarRentalClient.send("LIST \r\n");
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
                if (line_array[i].IndexOf("LIST_END") != -1)
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

        // SEARCH LOCATION TIME_START DAYS PRICE
        public static string[] search_parking_information(string []args)
        {
                string str = "SEARCH ";
                if (args[0] == null || args[0].Length == 0)
                    str += "NULL ";
                else
                    str += args[0] + " ";

                if (args[1] == null || args[1].Length == 0)
                    str += "NULL ";
                else
                    str += args[1] + " ";

                if (args[2] == null || args[2].Length == 0)
                    str += "NULL ";
                else
                    str += args[2] + " ";

                if (args[3] == null || args[3].Length == 0)
                    str += "NULL ";
                else
                    str += args[3] + " ";

            CarRentalClient.send(str + "\r\n");
            int is_closed = 0;
            int size = 16;
            string[] str_array = new string[size];

            string result = CarRentalClient.receive(ref is_closed);
            // 不断接受直到最后\r\n

            string[] line_array = result.Split('|');
            if (line_array[line_array.Length - 1].IndexOf("OTHER_WRONG") != -1)
                return null;

            for (int i = 0; ; ++i)
            {
                if (line_array[i].IndexOf("SUCCESS") != -1)
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