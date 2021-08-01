using System;
using System.Net;
using System.Net.Sockets;

namespace car_rental_client
{
    public class CarRentalClient
    {
        public static void StartClient()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse("8.136.218.156");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 50000);

                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}",
                    sender.RemoteEndPoint.ToString());

                byte[] msg = Encoding.ASCII.GetBytes("test\\r\\n");
                int bytesSent = sender.Send(msg);

                byte[] bytes = new byte[1024];
                int bytesRec = sender.Receive(bytes);
                Console.WriteLine("Echoed test = {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec));

                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}