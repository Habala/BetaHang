using BetaHang;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BetaHangServer
{
    public class Game
    {
        private object lockObject = new object();
        public List<ClientHandler> Clients = new List<ClientHandler>();
        string secretword;
        public bool InGame = false;
        public int MaxPlayers = 4;
        internal Action<ClientHandler, BHangMessage> echoMessageToForm;
        private string displayword;

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

            int wordsPlayed = 0;

            while (wordsPlayed < 6)
            {

                //entire game
                while (secretword != displayword)
                {
                    int waited = 0;
                    while (waited < 10)
                    {
                        BroadCast(new BHangMessage {Command= MessageCommand.timeLeft, Value = $"{10-waited}" });
                        Thread.Sleep(1000);
                        //broadcast 10-waited s left
                        waited++;
                    }

                    //handle guesses

                    //repeat
                }
                wordsPlayed++;
            }



            //end game and display final points...
        }

        private void BroadCast(BHangMessage message)
        {
            foreach (var tmpClient in Clients)
            {
                NetworkStream n = tmpClient.tcpClient.GetStream();
                BinaryWriter w = new BinaryWriter(n);
                var Jsonmsg = JsonConvert.SerializeObject(message);
                w.Write(Jsonmsg);
                w.Flush();
            }
        }

        private void handleClientMessage(string message)
        {

        }

        internal void messageHandler(ClientHandler sender, BHangMessage msg)
        {
            lock (lockObject)
            {
                switch (msg.Command)
                {

                    case MessageCommand.changeName:
                        sender.userName = msg.Value;
                        break;
                    case MessageCommand.guess:
                        sender.guess = msg.Value;
                        break;
                    case MessageCommand.isReady:
                        sender.IsReady = true;
                        break;
                    case MessageCommand.disconnect:
                        //todo: user disconnectar switch case
                        break;
                    default:
                        break;
                }

            }
            //do game stuff
            msg.Value += "Game touched this message";
            echoMessageToForm(sender, msg);
        }
    }
}
