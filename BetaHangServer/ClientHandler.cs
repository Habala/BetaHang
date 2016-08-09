using System;

namespace BetaHangServer
{
    internal class ClientHandler
    {
        Action<string> messageHandler;

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
    }
}