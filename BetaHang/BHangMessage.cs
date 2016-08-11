using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaHang
{
    public class BHangMessage
    {
        public MessageCommand Command { get; set; }
        public string Value { get; set; }
        public string[] ExtraValues { get; set; }

    }

    public enum MessageCommand
    {
        changeName,
        guess,
        isReady,
        disconnect,
        timeLeft,
        none,
        displayWord,
        score,
        endGame,
        newPlayer,
    }
}
