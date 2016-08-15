using BetaHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetaHangServer
{
    public partial class ServerForm : Form
    {
        private Server server;
        private Thread serverThread;
        public Game myGame;
        public ServerForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            #region Get local IP
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            textBoxServerIP.Text = localIP;
            textBoxServerIP.Enabled = false;
            #endregion

            myGame = new Game();
            myGame.onHiddenWordChange += DisplayHiddenWord;
            myGame.onMessageReceived += DisplayReceivedMessage;
            myGame.onMessageSent += DisplaySentMessages;

            server = new Server(myGame);
            server.onMessageReceived += DisplayReceivedMessage;
            server.onMessageSent += DisplaySentMessages;
            server.Start();


            var rnd = new Random();
            server.serverPass = "abc" + rnd.Next(10000);
            textBoxServerPW.Text = server.serverPass;
            textBoxServerPW.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DisplayHiddenWord(string hiddenWord)
        {
            HiddenWordBox.Text = hiddenWord;
        }
        private void DisplayReceivedMessage(ClientHandler sender, BHangMessage message)
        {
            string msgStr = sender.playerId;
            if (message.Value != null)
            {
                msgStr += " says: ";
                msgStr += message.Value;
            }
            msgStr += message.Command;
            if (message.ExtraValues != null)
                foreach (var item in message.ExtraValues)
                {
                    msgStr += " " + item;
                }

            lock (listBoxReceivedMessages)
            {
                listBoxReceivedMessages.Items.Insert(0, msgStr);
            }
        }

        private void DisplaySentMessages(BHangMessage message, ClientHandler receiver = null)
        {
            string msgStr = "";
            if (receiver != null)
                msgStr += receiver.playerId;
            else
                msgStr += "Broadcast";
            msgStr += " " + message.Command;

            if (message.Value != null)
            {
                msgStr += " : ";
                msgStr += message.Value;
            }
            if (message.ExtraValues != null)
                foreach (var item in message.ExtraValues)
                {
                    msgStr += " " + item;
                }

            lock (listBoxSentMessages)
            {
                listBoxSentMessages.Items.Insert(0,msgStr);
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myGame.RequestShutdown();
            server.RequestShutdown();
        }
    }
}
