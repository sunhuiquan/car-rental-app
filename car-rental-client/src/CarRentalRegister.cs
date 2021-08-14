using System;

namespace car_rental_client
{
    public class CarRentalRegister
    {
        public static bool register(string account, string password, string username, string phone, string pic_file_name)
        {
            string send_str = "REGISTER " + account + " " + password + " " + username + " " + phone + " \r\n";
            CarRentalClient.send(send_str);
            if (CarRentalClient.send_pic(pic_file_name) == -1)
                return false; ;

            int is_closed = 0;
            string response = CarRentalClient.receive(ref is_closed);
            string[] result_arrays = response.Split(' ');
            if (result_arrays[0].Equals("REGISTER_SUCCESS"))
                return true;
            return false;
        }
    }
}
