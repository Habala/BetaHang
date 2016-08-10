using BetaHang;
using Newtonsoft.Json;
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

namespace BetaHangClient
{
    public partial class ClientForm : Form
    {
        private Client myClient;

        public ClientForm()
        {
            InitializeComponent();

            myClient = new Client();
            myClient.onMessage += MessageHandler;

            //Thread clientThread = new Thread(myClient.Start);
            //clientThread.Start();
            myClient.Start();
            //clientThread.Join();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myClient.Send(new BHangMessage { Command = BetaHang.MessageCommand.guess, Value = "Button test" });
        }
        private void MessageHandler(BHangMessage message)
        {
            //textBox1.Text = message;
            textBox1.AppendText(message.Value);
            
            player1Label.Text = ""+(int)message.Command;

            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myClient.RequestShutdown();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            player1Label.Text = "Don't click me";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            var message = new BHangMessage
            {
                Command = MessageCommand.isReady,
                Value=""
            };
            myClient.Send(message);
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
