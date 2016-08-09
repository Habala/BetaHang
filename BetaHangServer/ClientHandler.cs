using System;
using System.Net.Sockets;

namespace BetaHangServer
{
    public class ClientHandler
    {

        public TcpClient tcpClient;
        Action<string> messageHandler;

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
            throw new NotImplementedException();
        }
    }
}