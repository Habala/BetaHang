using BetaHang;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Sockets;

namespace BetaHangServer
{
    public class ClientHandler
    {
        public TcpClient tcpClient;
        public event Action<ClientHandler, BHangMessage> onMessage;
        internal string playerId;
        internal string guess ="";
        internal int score;

        public bool IsReady { get; internal set; }

        public ClientHandler(TcpClient c)
        {
            this.tcpClient = c;
        }


        //Todo: use sender to send messages, make this.tcpClient private
        void sender(string message)
        {
            //send message to client.
        }

        internal void Listener()
        {
            try
            {
                BHangMessage message = null;

                while (true)
                {
                    NetworkStream n = tcpClient.GetStream();
                    string JsonTmpMsg = new BinaryReader(n).ReadString();
                    message = JsonConvert.DeserializeObject<BHangMessage>(JsonTmpMsg);

                    Logger.Log(message);
                    onMessage(this, message);
                }

                //myServer.DisconnectClient(this);
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message + ex.TargetSite);
            }
        }

    }
}