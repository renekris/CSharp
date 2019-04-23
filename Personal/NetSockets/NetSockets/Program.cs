using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace NetSockets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Dns.GetHostName());
            Console.ReadKey();
            Console.WriteLine("[1]> Be Client\n" +
                              "[2]> Be Server");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Mida sa tahad serverile saata?");
                    ExecuteClient(Console.ReadLine());
                    break;
                case ConsoleKey.D2:
                    ExecuteServer();
                    break;
            }

            Console.ReadKey();
        }

        public static void ExecuteServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(IPAddress.Loopback);
            IPAddress ipAddr = ipHost.AddressList[0];

            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 80);

            Socket listener = new Socket(ipAddr.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(localEndPoint);
            listener.Listen(10);

            while (true)
            {
                Console.WriteLine("Waiting connection ... ");
                Socket clientSocket = listener.Accept();

                byte[] bytes = new Byte[1024];
                string data = null;

                while (true)
                {

                    int numByte = clientSocket.Receive(bytes);

                    data += Encoding.Unicode.GetString(bytes, 0, numByte);

                    if (!String.IsNullOrEmpty(data))
                        break;
                }
                Console.Clear();
                Console.WriteLine("{0} ", data);
                //byte[] message = Encoding.Unicode.GetBytes("Test Server");
                //clientSocket.Send(message);

                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }

        static void ExecuteClient(string sendData)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(IPAddress.Loopback);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 80);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            sender.Connect(localEndPoint);

            //Console.WriteLine("Socket connected to -> {0} ", sender.RemoteEndPoint.ToString());
            byte[] messageSent = Encoding.Unicode.GetBytes(sendData);
            int byteSent = sender.Send(messageSent);

            byte[] messageReceived = new byte[1024];

            int byteRecv = sender.Receive(messageReceived);
            //Console.WriteLine("Message from Server -> {0}", Encoding.Unicode.GetString(messageReceived, 0, byteRecv));

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}
