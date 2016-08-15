using BetaHang;
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
        List<ClientHandler> ServerClients = new List<ClientHandler>();
        private Game pendingGame;
        private List<Game> runningGames = new List<Game>();
        //Hack: to force threads to shut down, might be better to have each client handle their threads
        //List<Thread> listenerThreads = new List<Thread>();
        bool shutdown = false;
        //List<TcpListener> listeners = new List<TcpListener>();
        internal string serverPass = "";
        private Thread serverListenerThread;
        TcpListener listener;

        internal event Action<BHangMessage,ClientHandler> onMessageSent;
        internal event Action<ClientHandler, BHangMessage> onMessageReceived;
        internal event Action<string> onHiddenWordChange;

        public void RequestShutdown()
        {
            shutdown = true;
            foreach (var item in ServerClients)
            {
                item?.RequestShutdown();
            }
            ServerClients = null;
            listener?.Stop();
            pendingGame.RequestShutdown();
            foreach (var item in runningGames)
            {
                item.RequestShutdown();
            }
        }
        public Server()
        {
            pendingGame = new Game();
            pendingGame.onMessageReceived += MessageHandler;
            //todo: handle sent messages and hidden word change
        }

        internal void Start()
        {
            serverListenerThread = new Thread(Run);
            serverListenerThread.Start();
        }

        public void Run()
        {

            //Console.WriteLine($"IP: {localIP}");

            listener = new TcpListener(IPAddress.Any, 5000);
            //Console.WriteLine("Server up and running, waiting for messages...");
            //listeners.Add(listener);
            try
            {
                listener.Start();

                while (!shutdown)
                {
                    TcpClient c = listener.AcceptTcpClient();
                    ClientHandler newClient = new ClientHandler(c /*, this.messageHandler*/);
                    ServerClients.Add(newClient);
                    newClient.onMessage += MessageHandler;


                    Thread clientThread = new Thread(newClient.Listener);
                    clientThread.Start();
                    //todo: next line might not be needed, part of attempts to get good shutdowns
                    //listenerThreads.Add(clientThread);


                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message + ex.TargetSite);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }



        //public void Broadcast(string message)
        //{
        //    try
        //    {
        //        foreach (ClientHandler tmpClient in ServerClients)
        //        {

        //            NetworkStream n = tmpClient.tcpClient.GetStream();
        //            BinaryWriter w = new BinaryWriter(n);
        //            w.Write(message);
        //            w.Flush();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex.Message + " " + ex.TargetSite);
        //    }
        //}
        private void MessageHandler(ClientHandler sender, BHangMessage message)
        {
            if (pendingGame == null)
                pendingGame = new Game();
            if(pendingGame.InGame || pendingGame.Clients.Count >= pendingGame.MaxPlayers)
            {
                runningGames.Add(pendingGame);
                pendingGame = new Game();
                pendingGame.onMessageReceived += MessageHandler;
                //todo: handle sent messages and hidden word change
            }
            //Todo: check all running games and remove any that have finished.

            try
            {

                sender.playerId = message.ExtraValues[0];

                bool added = false;
                if (pendingGame != null && serverPass == message.Value)
                {
                    added = pendingGame.AddPlayer(sender);

                }
                else if (serverPass != message.Value)
                {
                    var msg = new BHangMessage { Command = MessageCommand.ConnectionRefused, Value = "Invalid password!" };
                    sender.Send(msg);
                    onMessageSent?.Invoke(msg, sender);
                }
                else
                {
                    var msg = new BHangMessage { Command = MessageCommand.ConnectionRefused, Value = "Game does not exist!" };
                    sender.Send(msg);
                    onMessageSent(msg, sender);
                }
                if (added)
                    ServerClients.Remove(sender);
                if (!added)
                {
                    var msg = new BHangMessage { Command = MessageCommand.ConnectionRefused, Value = "Game refused you, you inferior creature!" };
                    sender.Send(msg);
                    onMessageSent(msg, sender);
                    ServerClients.Remove(sender);
                    sender.RequestShutdown();
                }
            }
            catch (Exception ex)
            {

                Logger.Error(ex.Message + " " + ex.TargetSite);
            }
            onMessageReceived?.Invoke(sender, message);
        }
    }
}
