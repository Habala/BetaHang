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
         public Action<string> messageHandler;

        public ClientHandler(TcpClient c, Action<string> broadcast)
        {
            this.tcpClient = c;
            messageHandler = broadcast;
        }

        public bool IsReady { get; internal set; }

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
                string message = "";
                //NetworkStream n;
                //dynamic JsonMessage;
                //Get username
                //n = tcpclient.GetStream();
                //message = new BinaryReader(n).ReadString();
                //JsonMessage = JsonConvert.DeserializeObject(message);
                //myServer.Broadcast(this, message);
                //this.userName = JsonMessage.message;
                //Console.WriteLine("User selected username: " + this.userName);

                while (!message.Equals("quit"))
                {
                    NetworkStream n = tcpClient.GetStream();
                    message = new BinaryReader(n).ReadString();
                    //JsonMessage = JsonConvert.DeserializeObject(message);
                    //if (JsonMessage.method == "send")
                        //myServer.Broadcast(this, (string)JsonMessage.message);
                    messageHandler(message);
                    //else if (JsonMessage.method == "command")
                    //    myServer.Command(this, JsonMessage);
                    //Console.WriteLine(this.userName + " sent " + message);
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