using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BetaHangClient
{

    public class Client
    {
        private TcpClient client;
        internal Action<string> onMessage;
        Thread listenerThread;
        public void Start()
        {
            #region Get local IP
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }

            //Console.WriteLine($"IP: {localIP}");
            #endregion

            //client = new TcpClient("192.168.220.69", 8080);
            client = new TcpClient(localIP, 5000);

            listenerThread = new Thread(Listen);
            listenerThread.Start();

            //Thread senderThread = new Thread(Send);
            //senderThread.Start();

            //senderThread.Join();
            //listenerThread.Join();
        }

        internal void Close()
        {
            //Todo: Kill listenerThread here...
        }

        public void Listen()
        {
            string message = "";

            try
            {
                while (true)
                {
                    NetworkStream n = client.GetStream();
                    message = new BinaryReader(n).ReadString();

                    //dynamic m = JsonConvert.DeserializeObject(message);
                    //Console.WriteLine("Raw message: " + message);
                    if (message == "quit")
                        break;
                    onMessage?.Invoke(message);
                    //Console.WriteLine("Other: " + message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //graceful exit?
        }

        public void Send(string message)
        {
            //string message = "";

            try
            {
                NetworkStream n = client.GetStream();

                //while (!message.Equals("quit"))
                //{
                //message = Console.ReadLine();
                BinaryWriter w = new BinaryWriter(n);
                //string JsonMessage = JsonConvert.SerializeObject(new { method = "send", message = message });
                w.Write(message);
                w.Flush();
                //}

                //client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
