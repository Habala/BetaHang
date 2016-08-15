using BetaHang;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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
        internal event Action<string> onHiddenWordChange;
        private char[] displayword = "somethingElse".ToArray();
        private Thread myThread;
        private bool shutdownRequested = false;
        Random rnd = new Random();
        internal event Action<BHangMessage, ClientHandler> onMessageSent;

        internal event Action<ClientHandler, BHangMessage> onMessageReceived;

        public void RequestShutdown()
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
            BroadCast(new BHangMessage { Command = MessageCommand.beginGame });
            string[] words = File.ReadAllLines("OrdTillBetaHang.txt", Encoding.Unicode);
            int wordsPlayed = 0;

            while (wordsPlayed < 6 && !shutdownRequested)
            {
                secretword = words[rnd.Next(words.Length)].ToUpper();
                displayword = (secretword.ToArray()
                  .Select(c => '*').ToArray());
                BroadCast(new BHangMessage { Command = MessageCommand.displayWord, Value = new string(displayword) });
                onHiddenWordChange(secretword);
                //entire game
                while (secretword != new string(displayword) && !shutdownRequested)
                {
                    int waited = 6;
                    while (waited > 0)
                    {
                        BroadCast(new BHangMessage { Command = MessageCommand.timeLeft, Value = $"{waited}" });
                        Thread.Sleep(1000);
                        //broadcast 10-waited s left
                        waited--;
 
                    }
                    var oldDisplayWord = (char[])displayword.Clone();
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
                Thread.Sleep(2000);
                wordsPlayed++;
                BroadCast(new BHangMessage { Command = MessageCommand.RoundNr, Value = wordsPlayed.ToString() });

            }



            //end game and display final points...
            BroadCast(new BHangMessage { Command = MessageCommand.endGame, Value = "Exit requested..." });
            foreach (var client in Clients)
            {
                client.RequestShutdown();
            }
        }


        private void playTimerSound(string c)
        {

            try
            {
                SoundPlayer sound = new SoundPlayer($@"{c}");
                sound.Play();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message + "" + ex.TargetSite);
            }
        }

        internal bool AddPlayer(ClientHandler newClient)
        {
            if (InGame)
                return false;
            if (newClient.playerId.Trim() == string.Empty)
            {
                var msg = new BHangMessage { Command = MessageCommand.ConnectionRefused, Value = "Do you even username? brah!" };
                newClient.Send(msg);
                onMessageSent?.Invoke(msg, newClient);
                return false;
            }

            bool userAdded = false;
            lock (Clients)
            {
                if (Clients.Where(c => c.playerId == newClient.playerId).Count() > 0)
                {
                    var msg = new BHangMessage { Command = MessageCommand.ConnectionRefused, Value = "Oh such an unoriginal username.." };
                    newClient.Send(msg);
                    onMessageSent?.Invoke(msg, newClient);
                }
                else if (Clients.Count >= MaxPlayers)
                {
                    var msg = new BHangMessage { Command = MessageCommand.ConnectionRefused, Value = "Early bird gets the worm. And you ain't no bird.....brah (Game is full)" };
                    newClient.Send(msg);
                    onMessageSent?.Invoke(msg, newClient);
                }
                else if (InGame)
                {
                    var msg = new BHangMessage { Command = MessageCommand.ConnectionRefused, Value = "You snooze, you lose (Game has already started)" };
                    newClient.Send(msg);
                    onMessageSent?.Invoke(msg, newClient);
                }
                else
                {
                    newClient.onMessage += messageHandler;
                    Clients.Add(newClient);
                    userAdded = true;
                    foreach (var client in Clients)
                    {
                        var msg = new BHangMessage { Command = MessageCommand.newPlayer, Value = client.playerId };
                        BroadCast(msg);
                        if (client.IsReady)
                        {
                            BroadCast(new BHangMessage { Command = MessageCommand.isReady, Value = client.playerId });
                        }
                    }
                }
            }
            return userAdded;

        }

        private void BroadCast(BHangMessage message)
        {
            try
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
            catch (Exception ex)
            {
                Logger.Error(ex.Message + ex.TargetSite);
            }
            onMessageSent?.Invoke(message,null);
        }


        internal void messageHandler(ClientHandler sender, BHangMessage msg)
        {
            string log = "";
            try
            {
                lock (lockObject)
                {
                    switch (msg.Command)
                    {

                        case MessageCommand.changeName:
                            //sender.playerId = msg.Value;
                            log = $"{sender.playerId} changed name to {msg.Value}";
                            BroadCast(new BHangMessage { Command = MessageCommand.changeName, Value = sender.playerId, ExtraValues = new string[] { msg.Value } });
                            break;
                        case MessageCommand.guess:
                            sender.guess = msg.Value;
                            break;
                        case MessageCommand.isReady:
                            sender.IsReady = true;
                            BroadCast(new BHangMessage { Command = MessageCommand.isReady, Value = sender.playerId });
                            log = $"set user {sender.playerId} ready";
                            break;
                        case MessageCommand.disconnect:
                            log = $"User {sender.playerId} disconnected";
                            //todo: user disconnectar switch case
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message + " " + ex.TargetSite);
            }

            onMessageReceived?.Invoke(sender, msg);
        }
    }
}
