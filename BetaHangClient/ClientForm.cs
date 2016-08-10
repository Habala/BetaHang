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
            myClient.Send("Klienten skickar testmeddelande");
        }
        private void MessageHandler(string message)
        {
            //textBox1.Text = message;
            textBox1.AppendText(message);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myClient.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
