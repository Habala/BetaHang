using BetaHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaHangClient
{
    class Gamestate
    {
        public List<Player> Players { get; set; }
        public string MyName { get; set; }
        public string DisplayWord { get; set; }
        public int timeLeft { get; private set; }

        public Action<Gamestate> onStateChange;

        public Gamestate()
        {
            MyName = "Please input name";
            DisplayWord = "* * * *";
            Players = new List<Player> {
                new Player { Name = "Player 1client"},
                new Player { Name = "Player 2client"},
                new Player { Name = "Player 3client"},
                new Player { Name = "Player 4client"}
            };
        }

        public class Player
        {
            public string Name { get; set; }
            public int Score { get; set; }
            public bool isReady = false;

            public Player()
            {
                Name = "Player x";
                Score = 0;
            }
        }


        public void ReceiveMessage(BHangMessage message)
        {
            Player player;

            switch (message.Command)
            {
                case MessageCommand.changeName:
                    MyName = message.Value;
                    break;
                case MessageCommand.isReady:
                    player = Players
                        .Where(p => p.Name == message.Value)
                        .SingleOrDefault();
                    player.isReady = true;
                    break;
                case MessageCommand.disconnect:
                    player = Players
                          .Where(p => p.Name == message.Value)
                          .SingleOrDefault();
                    player.isReady = false;
                    break;
                case MessageCommand.timeLeft:
                    this.timeLeft = int.Parse(message.Value);
                    break;
                case MessageCommand.none:

                    break;
                default:
                    break;
            }
            //todo: write to log
            //todo: handle messages to client form
            //if (onStateChange != null)
            onStateChange(this);
        }
    }
}
