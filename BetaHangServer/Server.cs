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
        public void Run()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 5000);
            Console.WriteLine("Server up and running, waiting for messages...");

            try
            {
                listener.Start();

                while (true)
                {
                    TcpClient c = listener.AcceptTcpClient();
                    ClientHandler newClient = new ClientHandler(c, this.Broadcast);
                    clients.Add(newClient);

                    Thread clientThread = new Thread(newClient.Run);
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                if (tmpClient != null)
                {
                    NetworkStream n = tmpClient.tcpClient.GetStream();
                    BinaryWriter w = new BinaryWriter(n);
                    //DataContractJsonSerializer
                    //w.Write(client.userName + " says: " + message);
                    w.Write(Jsonmessage);
                    w.Flush();
                }
                else if (clients.Count() == 1)
                {
                    NetworkStream n = tmpClient.tcpClient.GetStream();
                    BinaryWriter w = new BinaryWriter(n);
                    w.Write(JsonConvert.SerializeObject(
                        new { sender = "Server", message = $"Sorry you are all alone" }));
                    w.Flush();
                }
            }
        }
    }
}
