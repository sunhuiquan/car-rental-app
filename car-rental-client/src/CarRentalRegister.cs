using System;
using System.IO;

namespace car_rental_client
{
    public enum REGISTER_TYPE { SUCCESS, EMPTY, WRONG };
    public class CarRentalRegister
    {
        public static bool register(string account, string password, string username, string phone, string pic_file_name)
        {
            string send_str = "REGISTER " + account + " " + password + " " + username + " " + phone + " \r\n";
            CarRentalClient.send(send_str);

            int is_closed = 0;
            string r = CarRentalClient.receive(ref is_closed);
            if (!r.Split(' ')[0].Equals("SUCCESS"))
                return false;

            if (CarRentalClient.send_pic(pic_file_name) == -1)
                return false; ;

            is_closed = 0;
            string response = CarRentalClient.receive(ref is_closed);
            string[] result_arrays = response.Split(' ');
            if (result_arrays[0].Equals("REGISTER_SUCCESS"))
                return true;
            return false;
        }

        public static bool register_approve(string account)
        {
            // REGISTER_APPROVE ACCOUNT \r\n
            CarRentalClient.send("REGISTER_APPROVE " + account + " \r\n");

            int is_closed = 0;
            string response = CarRentalClient.receive(ref is_closed);
            string[] result_arrays = response.Split(' ');
            if (result_arrays[0].Equals("SUCCESS"))
                return true;
            return false;
        }

        public static bool register_fail(string account)
        {
            // REGISTER_FAIL ACCOUNT \r\n
            CarRentalClient.send("REGISTER_FAIL " + account + " \r\n");

            int is_closed = 0;
            string response = CarRentalClient.receive(ref is_closed);
            string[] result_arrays = response.Split(' ');
            if (result_arrays[0].Equals("SUCCESS"))
                return true;
            return false;
        }

        public const string path = "./pic/tmp_pic.png";

        public static REGISTER_TYPE get_next(ref string[] args)
        {
            CarRentalClient.send("GET_UNSURE_USER \r\n");
            int is_closed = 0;
            string result = CarRentalClient.receive(ref is_closed);
            string[] res_array = result.Split(' ');
            if (res_array[0].Equals("RESPONSE") && res_array.Length == 5)
            {
                try
                {
                    CarRentalClient.send("SUCCESS \r\n");

                    if (!Directory.Exists("./pic"))
                        Directory.CreateDirectory("./pic");
                    if (File.Exists(path))
                        File.Delete(path);
                    File.Create(path).Close();

                    args[0] = res_array[1];
                    args[1] = res_array[2];
                    args[2] = res_array[3];

                    result = CarRentalClient.receive(ref is_closed);
                    int length = int.Parse(result.Split(' ')[0]);
                    CarRentalClient.send("SUCCESS \r\n");

                    byte[] b = new byte[length + 100];
                    BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Append));
                    for (int l = 0; l < length;)
                    {
                        int len = CarRentalClient.client_socket.Receive(b);
                        bw.Write(b, 0, len);
                        l += len;
                    }
                    bw.Close();
                }
                catch (Exception)
                {
                    return REGISTER_TYPE.WRONG;
                }
                return REGISTER_TYPE.SUCCESS;
            }
            else if (res_array[0].Equals("EMPTY"))
                return REGISTER_TYPE.EMPTY;
            else
                return REGISTER_TYPE.WRONG;
        }
    }
}
