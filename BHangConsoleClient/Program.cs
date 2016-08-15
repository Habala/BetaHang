using BetaHangClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHangConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //CheckForIllegalCrossThreadCalls = false;
            Gamestate gameState = new Gamestate();
            //GameStateUpdate(gameState);
            gameState.onStateChange += DisplayState;
            var myClient = new Client();
            myClient.onMessage += gameState.ReceiveMessage;
            //myClient.onMessage += debugDisplay;
            myClient.Start();

            Console.WriteLine("press enter when ready");
            Console.ReadLine();
            myClient.Send(new BetaHang.BHangMessage { Command = BetaHang.MessageCommand.isReady, Value = "" });

            string input = "";
            while (input != "quit" && gameState.HasEnded == false)
            {
                input = Console.ReadLine();
                myClient.Send(new BetaHang.BHangMessage
                {
                    Command = BetaHang.MessageCommand.guess,
                    Value = input
                });
            }
            myClient.RequestShutdown();
        }

        static void DisplayState(Gamestate state)
        {
            Console.Clear();
            if (state.Players != null)
                for (int i = 0; i < state.Players.Count; i++)
                {
                    int change = state.Players[i].ScoreChange;
                    string playerstring = state.Players[i].Score.ToString();
                    playerstring += change > 0 ? $" (+{change})" : " (  )";
                    playerstring += " : " + state.Players[i].Guess;
                    playerstring += " : " + state.Players[i].Name;

                    Console.WriteLine(playerstring);
                }
            Console.WriteLine("Time Left: " + state.timeLeft);
            Console.WriteLine(state.DisplayWord);
            if(state.HasEnded)
                Console.WriteLine("Game Over!");
        }
    }
}
