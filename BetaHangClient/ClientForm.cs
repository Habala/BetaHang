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
            if (state.HasBegun)
                PanelGameStart.Hide();
            PlayerListBox.Items.Clear();

            if (state.Players != null)
                for (int i = 0; i < state.Players.Count && i < 4; i++)
                {
                    var playerName = state.Players[i].Name;
                    var playerGuess = state.Players[i].Guess;
                    var playerPoints = state.Players[i].Score;
                    var playerScoreChange = state.Players[i].ScoreChange;
                    var playerReady = state.Players[i].isReady ? "Ready": "Not ready";
                    PlayerListBox.Items.Add(playerName + " " + playerReady);
                    switch (i)
                    {
                        case 0:
                            player1Label.Text = playerName;
                            lblPlayerOneGuess.Text = playerGuess;
                            lblPlayerOnePoints.Text = playerPoints+ " " + playerScoreChange;
                            break;
                        case 1:
                            player2Label.Text = playerName;
                            lblPlayerTwoGuess.Text = playerGuess;
                            lblPlayerTwoPoints.Text = playerPoints + " " + playerScoreChange;
                            break;
                        case 2:
                            player3Label.Text = playerName;
                            lblPlayerThreeGuess.Text = playerGuess;
                            lblPlayerThreePoints.Text = playerPoints + " " + playerScoreChange;
                            break;
                        case 3:
                            player4Label.Text = playerName;
                            LblPlayerFourGuess.Text = playerGuess;
                            lblPlayerFourPoints.Text = playerPoints + " " + playerScoreChange;

                            break;
                        default:
                            break;
                    }
                }

            textBox1.Text = (state.timeLeft.ToString());
            LblDisplayWord.Text = state.DisplayWord;

        }

        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myClient.RequestShutdown();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            player1Label.Text = "Don't click me";
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

        

        private void buttonSubmitGuess_Click(object sender, EventArgs e)
        {
            myClient.SubmitGuess(textBoxGuess.Text);
            textBoxGuess.Text = "";

        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            string serverIP = tBServerIP.Text;
            string serverPassword = tBPassword.Text;
            string UserName = tBUserName.Text;

            myClient = new Client(serverIP);
            myClient.onMessage += gameState.ReceiveMessage;
            myClient.onMessage += debugDisplay;

            myClient.Start();

            myClient.Send(new BHangMessage { Command = MessageCommand.join, Value = serverPassword, ExtraValues = new string[] { UserName } });
        }

        private void btnReadyForGame_Click(object sender, EventArgs e)
        {
            myClient.Send(new BHangMessage { Command = MessageCommand.isReady, Value = "" });
        }
    }
}
