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
            myGame.echoMessageToForm = messageHandler;
            server = new Server(myGame);
            server.messageHandler = messageHandler;
            serverThread = new Thread(server.Run);
            serverThread.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.Broadcast("Servern skickar testmeddelande");
        }
        private void messageHandler(ClientHandler sender, BHangMessage message)
        {
            textBox1.Text = message.Value;
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myGame.RequestQuit();
            server.RequestShutdown();
        }
    }
}
