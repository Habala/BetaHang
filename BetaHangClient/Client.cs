using BetaHang;
using Newtonsoft.Json;
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
        public Action<BHangMessage> onMessage;
        Thread listenerThread;
        private bool shutdown = false;
        private string serverIP;

        public Client(string serverIP)
        {
            this.serverIP = serverIP;
        }

        public Client()
        {
        }

        public void RequestShutdown()
        {
            client.Close();
            shutdown = true;
        }
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

            //client = new TcpClient("192.168.220.27", 5000);
            //client = new TcpClient(localIP, 5000);
            client = new TcpClient(serverIP, 5000);
            listenerThread = new Thread(Listen);
            listenerThread.Start();

            //Thread senderThread = new Thread(Send);
            //senderThread.Start();

            //senderThread.Join();
            //listenerThread.Join();
        }

        

        public void Listen()
        {
            string jsonMessage = "";

            try
            {
                while (!shutdown)
                {
                    NetworkStream n = client.GetStream();
                    jsonMessage = new BinaryReader(n).ReadString();

                    //dynamic m = JsonConvert.DeserializeObject(message);
                    //Console.WriteLine("Raw message: " + message);
                    BHangMessage message = JsonConvert.DeserializeObject<BHangMessage>(jsonMessage);
                    Logger.Log(message);
                    onMessage?.Invoke(message);
                    //Console.WriteLine("Other: " + message);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message + ex.TargetSite);
            }
            //graceful exit?
        }

        public void Send(BHangMessage message)
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
                string tmpJson = JsonConvert.SerializeObject(message);
                   
                w.Write(tmpJson);
                w.Flush();
                //}

                //client.Close();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message + ex.TargetSite);
            }
        }

        internal void SubmitGuess(string text)
        {
            var guess = text;
            if (guess == null || guess == "")
                return;
            var message = new BHangMessage
            {
                Command = MessageCommand.guess,
                Value = guess
            };
            Send(message);
        }
    }
}
