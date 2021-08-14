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

            for(int i = 0; ;++i)
            {
                string str = CarRentalClient.receive(ref is_closed);
                if(str.Split(' ')[0].Equals("OTHER_WRONG"))
                    return null;

                if (str.Split(' ')[0].Equals("LIST_END"))
                    break;

                if (i == size - 1)
                {
                    string []temp = new string[size * 2];
                    for (int j = 0; j < str_array.Length; ++j)
                        temp[j] = str_array[j];
                    str_array = temp;
                }
                str_array[i] = str;
            }
            return str_array;
        }
    }
}