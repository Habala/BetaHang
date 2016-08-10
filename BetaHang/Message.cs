using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaHang
{
    class Message
    {
        public MessageCommand Command { get; set; }
        public string Value { get; set; }
    }
    public enum MessageCommand
    {
        changeName,
        guess
    }
}
