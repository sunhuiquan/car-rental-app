using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental_client
{
    class CarRentalMessage
    {
        public static int announce(string message)
        {
            // ANNOUNCE \r\n
            // (wait until accept a SUCCESS)
            // 传数据(textBox的行也是\r\n)
            // ANNOUNCE_END \r\n

            CarRentalClient.send("ANNOUNCE \r\n");
            int is_closed = 0;
            string str = CarRentalClient.receive(ref is_closed);
            if (!str.Split(' ')[0].Equals("SUCCESS"))
                return -1;

            CarRentalClient.send(message + "\r\n"); // 保证以\r\n结尾
            CarRentalClient.send("ANNOUNCE_END \r\n");

            is_closed = 0;
            str = CarRentalClient.receive(ref is_closed);
            Console.WriteLine(str);
            if (str.Split(' ')[0].Equals("SUCCESS"))
                return 0;
            return -1;
        }

        public static string get_announce()
        {
            // ANNOUNCE \r\n
            // (wait until accept a SUCCESS)
            // 传数据(textBox的行也是\r\n)
            // ANNOUNCE_END \r\n

            CarRentalClient.send("GET_ANNOUNCE \r\n");

            byte[] bytes = new Byte[1024];
            string recv = null;
            while (true)
            {
                int bytesRec = CarRentalClient.client_socket.Receive(bytes);
                recv += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                if (recv.IndexOf("SUCCESS \r\n") > -1)
                    break;
            }

            if (recv == null)
                return recv;
            return recv.Substring(0, recv.IndexOf("SUCCESS \r\n"));
        }

        public static string get_user_message(string account)
        {
            // GET_USER_MESSAGE ACCOUNT \r\n
            CarRentalClient.send("GET_USER_MESSAGE " + account + " \r\n");

            byte[] bytes = new Byte[1024];
            string recv = null;
            while (true)
            {
                int bytesRec = CarRentalClient.client_socket.Receive(bytes);
                recv += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                if (recv.IndexOf("SUCCESS \r\n") > -1)
                    break;
            }

            if (recv == null)
                return recv;
            return recv.Substring(0, recv.IndexOf("SUCCESS \r\n"));
        }

         public static int put_message_to_user(string account,string message)
        {
            // PUT_MESSAGE_TO_USER ACCOUNT \r\n
            // (wait until accept a SUCCESS)
            // 传数据(textBox的行也是\r\n)
            // MESSAGE_END \r\n

            CarRentalClient.send("PUT_MESSAGE_TO_USER " + account + " \r\n");
            int is_closed = 0;
            string str = CarRentalClient.receive(ref is_closed);
            if (!str.Split(' ')[0].Equals("SUCCESS"))
                return -1;

            CarRentalClient.send(message + "\r\n"); // 保证以\r\n结尾
            CarRentalClient.send("MESSAGE_END \r\n");

            is_closed = 0;
            str = CarRentalClient.receive(ref is_closed);
            Console.WriteLine(str);
            if (str.Split(' ')[0].Equals("SUCCESS"))
                return 0;
            return -1;
        }

        public static int put_message_to_admin(string account, string message)
        {
            // PUT_MESSAGE_TO_ADMIN ACCOUNT \r\n
            // (wait until accept a SUCCESS)
            // 传数据(textBox的行也是\r\n)
            // MESSAGE_END \r\n

            CarRentalClient.send("PUT_MESSAGE_TO_ADMIN " + account + " \r\n");
            int is_closed = 0;
            string str = CarRentalClient.receive(ref is_closed);
            if (!str.Split(' ')[0].Equals("SUCCESS"))
                return -1;

            CarRentalClient.send(message + "\r\n"); // 保证以\r\n结尾
            CarRentalClient.send("MESSAGE_END \r\n");

            is_closed = 0;
            str = CarRentalClient.receive(ref is_closed);
            Console.WriteLine(str);
            if (str.Split(' ')[0].Equals("SUCCESS"))
                return 0;
            return -1;
        }

        public static string get_admin_message()
        {
            // GET_ADMIN_MESSAGE \r\n
            CarRentalClient.send("GET_ADMIN_MESSAGE \r\n");

            byte[] bytes = new Byte[1024];
            string recv = null;
            while (true)
            {
                int bytesRec = CarRentalClient.client_socket.Receive(bytes);
                recv += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                if (recv.IndexOf("SUCCESS \r\n") > -1)
                    break;
            }

            if (recv == null)
                return recv;
            return recv.Substring(0, recv.IndexOf("SUCCESS \r\n"));
        }
    }
}
