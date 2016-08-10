using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetaHangServer
{
    public partial class Form1 : Form
    {
        private Server server;
        public Form1()
        {
            InitializeComponent();
            server = new Server();
            server.messageHandler = messageHandler;
            Thread myThread = new Thread(server.Run);
            myThread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.Broadcast("Servern skickar testmeddelande");
        }
        private void messageHandler(string message)
        {
            textBox1.Text = message;
        }
    }
}
