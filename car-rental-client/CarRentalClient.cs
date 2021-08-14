using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.IO;

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

        public static int send_pic(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                Byte[] imgByte = new Byte[fs.Length];
                fs.Read(imgByte, 0, imgByte.Length);
                fs.Close();
                client_socket.Send(imgByte);
                client_socket.Send(Encoding.ASCII.GetBytes(" \r\n"));
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        public static string receive(ref int is_closed)
        {
            byte[] bytes = new Byte[1024];
            string request = null;

            while (true)
            {
                int bytesRec = client_socket.Receive(bytes);
                // 正常这样没有数据可读会阻塞，0说明对端套接字已经关闭，
                // 最重要的是关闭在 \r\n 之前说明这个指令不全，需要舍弃
                if (bytesRec == 0)
                {
                    is_closed = 1;
                    break;
                }
                request += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (request.IndexOf("\r\n") > -1)
                    break;
            }
            return request;
        }

        public static void close()
        {
            client_socket.Shutdown(SocketShutdown.Both);
            client_socket.Close();
        }
    }
}