using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BetaHangServer
{
    class Game
    {
        List<ClientHandler> Clients;
        string secretword;
        public bool InGame = false;
        public int MaxPlayers = 4;

        public Game()
        {
            Thread myThread = new Thread(Run);
            myThread.Start();
        }
        private void Run()
        {
            //secretword = Randomizer.SecretWord();

            //wait for players
            bool waitingForClients = true;
            while (waitingForClients)
            {

                lock (Clients)
                {
                    if (Clients.Count >= 2 && Clients.All(c => c.IsReady))
                    {
                        waitingForClients = false;
                        InGame = true;
                    }
                }
                Thread.Sleep(50);
                //Wait for cilents to be ready.
                if (Clients.Count > MaxPlayers)
                    throw new Exception("Server added too many players, stupid server!");
            }

            while (InGame)
            {
                //run game here
                
            }
            //end game and display final points...
        }
        private void handleClientMessage(string message)
        {

        }


    }
}
