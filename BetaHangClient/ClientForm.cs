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
            if (state.Players != null)
                for (int i = 0; i < state.Players.Count && i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            player1Label.Text = state.Players[0].Name;
                            lblPlayerOneGuess.Text = state.Players[0].Guess;
                            lblPlayerOnePoints.Text = state.Players[0].Score.ToString();
                            break;
                        case 1:
                            player2Label.Text = state.Players[1].Name;
                            lblPlayerTwoGuess.Text = state.Players[1].Guess;
                            lblPlayerTwoPoints.Text = state.Players[1].Score.ToString();
                            break;
                        case 2:
                            player3Label.Text = state.Players[2].Name;
                            lblPlayerThreeGuess.Text = state.Players[2].Guess;
                            lblPlayerThreePoints.Text = state.Players[2].Score.ToString();
                            break;
                        case 3:
                            player4Label.Text = state.Players[3].Name;
                            LblPlayerFourGuess.Text = state.Players[3].Guess;
                            lblPlayerFourPoints.Text = state.Players[3].Score.ToString();

                            break;
                        default:
                            break;
                    }
                }

            textBox1.Text = (state.timeLeft.ToString());
            LblDisplayWord.Text = state.DisplayWord;

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    myClient.Send(new BHangMessage { Command = BetaHang.MessageCommand.guess, Value = "Button test" });
        //}

        //private void MessageHandler(BHangMessage message)
        //{
        //    //textBox1.Text = message;
        //    textBox1.AppendText(message.Value);

        //    player1Label.Text = "" + (int)message.Command;


        //}

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
            myClient.SubmitGuess(textBoxGuess.Text);
            textBoxGuess.Text = "";

        }

        private void textBoxGuess_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }


    }
}
