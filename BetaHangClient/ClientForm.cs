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
        private Gamestate gameState;

        public ClientForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            gameState = new Gamestate();
            GameStateUpdate(gameState);
            gameState.onStateChange = GameStateUpdate;
            myClient = new Client();
            myClient.onMessage += gameState.ReceiveMessage;
            myClient.onMessage += debugDisplay;

            myClient.Start();

        }

        private void debugDisplay(BHangMessage obj)
        {
            if (obj.Command == MessageCommand.timeLeft)
                return;
            string msges = obj.Command + " ";
            if (obj.Value != null)
                msges += obj.Value + " ";
            if (obj.ExtraValues != null)
                foreach (var item in obj.ExtraValues)
                {
                    msges += item + " ";
                }
            //listBoxDebug.Items.Add(msges);
            listBoxDebug.Items.Insert(0, msges);
        }

        private void GameStateUpdate(Gamestate state)
        {
            player1Label.Text = state.Players[0].Name;
            player2Label.Text = state.Players[1].Name;
            player3Label.Text = state.Players[2].Name;
            player4Label.Text = state.Players[3].Name;

            textBox1.AppendText(state.timeLeft.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myClient.Send(new BHangMessage { Command = BetaHang.MessageCommand.guess, Value = "Button test" });
        }
        private void MessageHandler(BHangMessage message)
        {
            //textBox1.Text = message;
            textBox1.AppendText(message.Value);

            player1Label.Text = "" + (int)message.Command;


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
                Value = ""
            };
            myClient.Send(message);
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSubmitGuess_Click(object sender, EventArgs e)
        {
            var guess = textBoxGuess.Text;
            if (guess == null || guess == "")
                return;
            var message = new BHangMessage
            {
                Command = MessageCommand.guess,
                Value = guess
            };
            myClient.Send(message);
        }
    }
}
