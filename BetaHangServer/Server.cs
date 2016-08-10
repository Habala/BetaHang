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

namespace BetaHangServer
{
    class Server
    {
        List<ClientHandler> clients = new List<ClientHandler>();
        internal Action<string> messageHandler;
        private Game myGame;

        public Server(Game myGame)
        {
            this.myGame = myGame;
        }

        public void Run()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 5000);
            //Console.WriteLine("Server up and running, waiting for messages...");

            try
            {
                listener.Start();

                while (true)
                {
                    TcpClient c = listener.AcceptTcpClient();
                    ClientHandler newClient = new ClientHandler(c, this.messageHandler);
                    clients.Add(newClient);

                    Thread clientThread = new Thread(newClient.Run);
                    clientThread.Start();

                    lock (myGame.Clients)
                    {
                        if (!myGame.InGame && myGame.Clients.Count < myGame.MaxPlayers)
                        {
                            newClient.messageHandler -= this.messageHandler;
                            newClient.messageHandler += myGame.messageHandler;
                            clients.Remove(newClient);
                            myGame.Clients.Add(newClient);
                        }
                        else
                        {
                            //newClient.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }

        public void Broadcast(string message)
        {
            var Jsonmessage = "";
            //var Jsonmessage = JsonConvert.SerializeObject(new { sender = client.userName, message = message });
            foreach (ClientHandler tmpClient in clients)
            {

                NetworkStream n = tmpClient.tcpClient.GetStream();
                BinaryWriter w = new BinaryWriter(n);
                //DataContractJsonSerializer
                //w.Write(client.userName + " says: " + message);
                w.Write(message);
                w.Flush();

                //else if (clients.Count() == 1)
                //{
                //    NetworkStream n = tmpClient.tcpClient.GetStream();
                //    BinaryWriter w = new BinaryWriter(n);
                //    w.Write(JsonConvert.SerializeObject(
                //        new { sender = "Server", message = $"Sorry you are all alone" }));
                //    w.Flush();
                //}
            }
        }
    }
}
