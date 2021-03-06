﻿using BetaHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetaHangClient
{
    public class Gamestate
    {
        public List<Player> Players { get; set; }
        public string MyName { get; set; }
        public string DisplayWord { get; set; }
        public int timeLeft { get; private set; }
        public bool HasEnded { get; set; }
        public bool HasBegun { get; set; }
        public int Round { get; set; }
        public int MaxScore
        {
            get
            {
                int max = 0;
                if (Players != null)
                {
                    foreach (var item in Players)
                    {
                        if (item.Score > max)
                        {
                            max = item.Score;
                        }
                    }
                
                }
                return max;
            }
        }

        public event Action<Gamestate> onStateChange;
        public event Action<Gamestate> onHasEnded;

        public event Action<BHangMessage> onConnectionRefused;

        public Gamestate()
        {
            MyName = "Please input name";
            DisplayWord = "* * * *";
            Players = new List<Player>();
        }

        public class Player
        {

            public string Name { get; set; }
            private int score;
            public int Score
            {
                get { return score; }
                set
                {
                    int oldScore = score;
                    score = value;
                    ScoreChange = score - oldScore;
                }
            }
            public bool isReady = false;
            public string Id { get; set; }
            public string Guess { get; set; }
            public int ScoreChange { get; set; }

            public Player(string Id)
            {
                Guess = "";
                this.Id = Id;
                Name = Id;
                Score = 0;
            }
        }


        public void ReceiveMessage(BHangMessage message)
        {
            Player player;
            try
            {
                switch (message.Command)
                {
                    case MessageCommand.changeName:
                        player = Players.Where(p => p.Id == message.Value).SingleOrDefault();
                        if (player != null)
                            player.Name = message.ExtraValues[0];
                        break;
                    case MessageCommand.isReady:
                        player = Players
                            .Where(p => p.Id == message.Value)
                            .SingleOrDefault();
                        player.isReady = true;
                        break;
                    case MessageCommand.disconnect:
                        player = Players
                              .Where(p => p.Id == message.Value)
                              .SingleOrDefault();
                        player.isReady = false;
                        break;
                    case MessageCommand.timeLeft:
                        this.timeLeft = int.Parse(message.Value);
                        break;
                    case MessageCommand.newPlayer:
                        if (Players.Where(c => c.Id == message.Value).Count() == 0)
                        {
                            this.Players.Add(new Player(message.Value));
                        }
                        break;
                    case MessageCommand.displayWord:
                        this.DisplayWord = message.Value == null ? "" : message.Value;
                        break;
                    case MessageCommand.score:
                        player = this.Players.Where(p => p.Id == message.Value).SingleOrDefault();
                        if (player != null)
                        {
                            player.Score = int.Parse(message.ExtraValues[0]);
                        }
                        break;
                    case MessageCommand.RoundNr:
                        Round = int.Parse(message.Value);
                        break;
                    case MessageCommand.guess:
                        player = this.Players.Where(p => p.Id == message.Value).SingleOrDefault();
                        if (player != null)
                        {
                            player.Guess = (message.ExtraValues[0]);
                        }
                        break;
                    case MessageCommand.endGame:
                        HasEnded = true;
                        onHasEnded?.Invoke(this);
                        break;
                    case MessageCommand.beginGame:
                        HasBegun = true;
                        break;
                    case MessageCommand.ConnectionRefused:
                        //MessageBox.Show(message.Value);
                        onConnectionRefused?.Invoke(message);
                        break;

                    case MessageCommand.none:

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                Logger.Error(ex.Message + ex.TargetSite);
            }

            onStateChange(this);

        }
    }
}
