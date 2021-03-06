﻿using BetaHang;
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
        internal string guess = "";
        internal int score;
        private bool shutdownRequested;

        public bool IsReady { get; internal set; }

        public ClientHandler(TcpClient c)
        {
            this.tcpClient = c;
        }

        public void Send(BHangMessage message)
        {

            try
            {

                    NetworkStream n = tcpClient.GetStream();
                    BinaryWriter w = new BinaryWriter(n);
                    string JsonMessage = JsonConvert.SerializeObject(message);
                    w.Write(JsonMessage);
                    w.Flush();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message + " " + ex.TargetSite);
            }

        }

        internal void Listener()
        {
            try
            {
                BHangMessage message = null;

                while (!shutdownRequested)
                {
                    NetworkStream n = tcpClient.GetStream();
                    string JsonTmpMsg = new BinaryReader(n).ReadString();
                    message = JsonConvert.DeserializeObject<BHangMessage>(JsonTmpMsg);

                    Logger.Log(message);
                    onMessage(this, message);
                }

                //myServer.DisconnectClient(this);
                //tcpClient.Close();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message + ex.TargetSite);
            }
        }

        internal void RequestShutdown()
        {
            //todo: Close tcpclient and listenerthread.
            shutdownRequested = true;
            tcpClient.Close();
        }
    }
}