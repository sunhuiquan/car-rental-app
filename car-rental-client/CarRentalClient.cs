using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace car_rental_client
{
    public class CarRentalClient
    {
        const bool is_debug = true;
        static Socket client_socket = null;
        public static int connect()
        {
            try
            {
                IPAddress ipAddress;
                if (is_debug)
                    ipAddress = IPAddress.Parse("127.0.0.1");
                else
                    ipAddress = IPAddress.Parse("8.136.218.156");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 50000);
                client_socket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                client_socket.Connect(remoteEP);
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
        }

        public static int send(string msg)
        {
            return client_socket.Send(Encoding.ASCII.GetBytes(msg));
        }

        public static string receive()
        {
            string msg = "";
            int read_num;
            byte[] bytes = new byte[1024];
            while (true)
            {
                read_num = client_socket.Receive(bytes);
                msg += Encoding.ASCII.GetString(bytes);
                if (read_num == 0)
                    break;
            }
            return msg;
        }

        public static void close()
        {
            client_socket.Shutdown(SocketShutdown.Both);
            client_socket.Close();
        }
    }
}