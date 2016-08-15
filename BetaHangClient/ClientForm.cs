using BetaHang;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
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
        SoundPlayer sound;
        bool musicStarted;


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
            {
                PanelGameStart.Hide();
                playSound(@"Tunes\BetaHang.wav");

            }
            PlayerListBox.Items.Clear();

            string playerMaxScore = state.MaxScore.ToString();

            if (state.Players != null)
                for (int i = 0; i < 4; i++)
                {
                    var playerName = "";
                    var playerGuess = "";
                    var playerPoints = "";
                    var playerScoreChange = "";
                    var playerReady = "";


                    if (i < state.Players.Count())
                    {
                        var player = state.Players[i];
                        playerName = state.Players[i].Name;
                        playerGuess = state.Players[i].Guess;
                        playerPoints = state.Players[i].Score.ToString();
                        int change = state.Players[i].ScoreChange;
                        if (change > 0)
                        {
                            playerScoreChange = $"(+{change})";
                        }
                        else
                        {
                            playerScoreChange = "";
                        }
                        playerReady = state.Players[i].isReady ? "Ready" : "Not ready";

                    }

                    PlayerListBox.Items.Add(playerName + " " + playerReady);
                    switch (i)
                    {  
                        case 0:
                            setBold(player1Label, playerPoints == playerMaxScore);
                            player1Label.Text = playerName;
                            lblPlayerOneGuess.Text = playerGuess;
                            setPointColour(lblPlayerOnePoints, playerScoreChange != string.Empty);
                            lblPlayerOnePoints.Text = playerPoints + " " + playerScoreChange;
                            break;
                        case 1:
                            setBold(player2Label, playerPoints == playerMaxScore);
                            player2Label.Text = playerName;
                            lblPlayerTwoGuess.Text = playerGuess;
                            setPointColour(lblPlayerTwoPoints, playerScoreChange != string.Empty);
                            lblPlayerTwoPoints.Text = playerPoints + " " + playerScoreChange;
                            break;
                        case 2:
                            setBold(player3Label, playerPoints == playerMaxScore);
                            player3Label.Text = playerName;
                            lblPlayerThreeGuess.Text = playerGuess;
                            setPointColour(lblPlayerThreePoints, playerScoreChange != string.Empty);
                            lblPlayerThreePoints.Text = playerPoints + " " + playerScoreChange;
                            break;
                        case 3:
                            setBold(player4Label, playerPoints == playerMaxScore);
                            player4Label.Text = playerName;
                            LblPlayerFourGuess.Text = playerGuess;
                            setPointColour(lblPlayerFourPoints, playerScoreChange != string.Empty);
                            lblPlayerFourPoints.Text = playerPoints + " " + playerScoreChange;

                            break;
                        default:
                            break;
                    }
                }

            lblCountDown.Text = (state.timeLeft.ToString());
            LblDisplayWord.Text = state.DisplayWord;
            lblRound.Text = $"Round: {state.Round}";


        }

        private void setPointColour(Label lbl, bool b)
        {
            if (b)
            {
                lbl.ForeColor = Color.Green;
            }
            else
            {
                lbl.ForeColor = Color.Black;
            }
        }

        private void setBold(Label label, bool b)
        {
            if (b)
            {
                label.Font = new Font(label.Font, FontStyle.Bold);
            }
            else
            {
                label.Font = new Font(label.Font, FontStyle.Regular);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myClient != null)
            myClient.RequestShutdown();
            if (sound != null)
            {
                sound.Stop();
            }
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

            try
            {

                myClient = new Client(serverIP);
                myClient.onMessage += gameState.ReceiveMessage;
                myClient.onMessage += debugDisplay;

                myClient.Start();
                
                myClient.Send(new BHangMessage { Command = MessageCommand.join, Value = serverPassword, ExtraValues = new string[] { UserName } });
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message + " " + ex.TargetSite);
                MessageBox.Show("Connection to server failed: " + ex.Message);
            }
       

        }

        private void btnReadyForGame_Click(object sender, EventArgs e)
        {
            myClient.Send(new BHangMessage { Command = MessageCommand.isReady, Value = "" });
        }

        private void playSound(string c)
        {
            if (musicStarted == false)
            {

                try
                {
                    SoundPlayer sound = new SoundPlayer($@"{c}");
                    sound.PlayLooping();
                    musicStarted = true;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message + "" + ex.TargetSite);
                }
            }
            
        }
    }
}
