using BetaHang;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Sockets;

namespace BetaHangServer
{
    public class ClientHandler
    {
        //private Server myServer;
        //public string userName;
        public TcpClient tcpClient;
        public event Action<ClientHandler, BHangMessage> onMessage2;
        public Action<ClientHandler, BHangMessage> onMessage;
        internal string userName;
        internal string guess;
        public bool IsReady { get; internal set; }

        public ClientHandler(TcpClient c/*, Action<ClientHandler, BHangMessage> broadcast*/)
        {
            this.tcpClient = c;
            //messageHandler = broadcast;
        }


        void Listener()
        {
            string message = "";

            //  messageHandler(message);
        }
        void sender(string message)
        {
            //send message to client.
        }

        internal void Run()
        {
            try
            {
                BHangMessage message = null;
                //NetworkStream n;
                //dynamic JsonMessage;
                //Get username
                //n = tcpclient.GetStream();
                //message = new BinaryReader(n).ReadString();
                //JsonMessage = JsonConvert.DeserializeObject(message);
                //myServer.Broadcast(this, message);
                //this.userName = JsonMessage.message;
                //Console.WriteLine("User selected username: " + this.userName);

                while (true)
                {
                    NetworkStream n = tcpClient.GetStream();
                    string JsonTmpMsg = new BinaryReader(n).ReadString();
                    message = JsonConvert.DeserializeObject<BHangMessage>(JsonTmpMsg);

                    
                    onMessage(this, message);

                    //todo: change to event onMessage2?.Invoke(this, message);
                }

                //myServer.DisconnectClient(this);
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}