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
        string secretword = "testa";
        public bool InGame = false;
        public int MaxPlayers = 4;
        internal Action<ClientHandler, BHangMessage> echoMessageToForm;
        private char[] displayword = "somethingElse".ToArray();
        private Thread myThread;
        private bool shutdownRequested = false;
        Random rnd = new Random();
        public void RequestQuit()
        {
            shutdownRequested = true;
        }

        public Game()
        {
            myThread = new Thread(Run);
            myThread.Start();
        }
        private void Run()
        {
            //secretword = Randomizer.SecretWord();

            //wait for players
            bool waitingForClients = true;
            while (waitingForClients && !shutdownRequested)
            {
                lock (Clients)
                {
                    if (Clients.Count >= 1 && Clients.All(c => c.IsReady))
                    {
                        waitingForClients = false;
                        InGame = true;
                    }
                }
                Thread.Sleep(50);
                //Wait for cilents to be ready.
            }

            string[] words = File.ReadAllLines("OrdTillBetaHang.txt", Encoding.Unicode);
            int wordsPlayed = 0;

            while (wordsPlayed < 6 && !shutdownRequested)
            {
                secretword = words[rnd.Next(words.Length)].ToUpper();
                displayword = (secretword.ToArray()
                  .Select(c => '*').ToArray());
                BroadCast(new BHangMessage { Command = MessageCommand.displayWord, Value = new string(displayword) });
                echoMessageToForm(null, new BHangMessage { Command = MessageCommand.none, Value = secretword });
                //entire game
                while (secretword != new string(displayword) && !shutdownRequested)
                {
                    int waited = 0;
                    while (waited < 6)
                    {
                        BroadCast(new BHangMessage { Command = MessageCommand.timeLeft, Value = $"{10 - waited}" });
                        Thread.Sleep(1000);
                        //broadcast 10-waited s left
                        waited++;
                    }
                    var oldDisplayWord = displayword;
                    foreach (var client in Clients)
                    {
                        var guess = client.guess?.ToUpper();
                        int correct = 0;
                        if (guess != null && guess.Length == 1)
                        {
                            for (int i = 0; i < secretword.Length; i++)
                            {
                                if (oldDisplayWord[i] == '*' && guess[0] == secretword[i])
                                {
                                    displayword[i] = secretword[i];
                                    correct++;
                                }
                            }
                        }
                        else if (guess == secretword)
                        {
                            correct = oldDisplayWord.Where(c => c == '*').Count();
                            displayword = secretword.ToArray();
                        }

                        client.score += correct;
                        BroadCast(new BHangMessage { Command = MessageCommand.score, Value = client.playerId, ExtraValues = new string[] { client.score.ToString() } });
                        BroadCast(new BHangMessage { Command = MessageCommand.guess, Value = client.playerId, ExtraValues = new string[] { client.guess } });
                        client.guess = "";
                    }
                    var msg = new BHangMessage { Command = MessageCommand.displayWord, Value = new string(displayword) };
                    BroadCast(msg);
                }
                BroadCast(new BHangMessage { Command = MessageCommand.displayWord, Value = secretword });
                Thread.Sleep(1500);
                wordsPlayed++;

            }



            //end game and display final points...
            BroadCast(new BHangMessage { Command = MessageCommand.endGame, Value = "Exit requested..." });
        }

        internal bool AddPlayer(ClientHandler newClient)
        {
            if (InGame)
                return false;

            bool userAdded = false;
            lock (Clients)
            {
                if (!InGame && Clients.Count < MaxPlayers)
                {
                    newClient.playerId = $"Player {Clients.Count + 1}";
                    newClient.onMessage += messageHandler;
                    //todo: change to event newClient.onMessage2 += messageHandler;
                    Clients.Add(newClient);
                    userAdded = true;
                    foreach (var client in Clients)
                    {
                    var msg = new BHangMessage {Command = MessageCommand.newPlayer, Value=client.playerId };
                    BroadCast(msg);
                    }
                }
            }
            return userAdded;

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
            string log = "";
            lock (lockObject)
            {
                switch (msg.Command)
                {

                    case MessageCommand.changeName:
                        sender.playerId = msg.Value;
                        break;
                    case MessageCommand.guess:
                        sender.guess = msg.Value;
                        break;
                    case MessageCommand.isReady:
                        sender.IsReady = true;
                        log = $"set user {sender.playerId} ready";
                        break;
                    case MessageCommand.disconnect:
                        //todo: user disconnectar switch case
                        break;
                    default:
                        break;
                }
            }
            //do game stuff
            var newMsg = new BHangMessage { Value = log };
            echoMessageToForm(null, newMsg);
        }
    }
}
