using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaHang
{
    public static class Logger
    {
        private static object _logLock = new object();
        private static object _errorLock = new object();
        private static string logFile = "log.txt";
        private static string errorFile = "error.txt";
        public static void Log(string logText)
        {
            var time = System.DateTime.Now;
            var builder = new StringBuilder();
            builder.Append(time.Hour + ":" + time.Minute + " ");
            builder.Append(logText);
            lock (_logLock)
            {
                File.AppendAllText(logFile, builder.ToString());
            }
        }
        public static void Error(string errorText)
        {
            var time = System.DateTime.Now;
            var builder = new StringBuilder();
            builder.Append(time.Hour + ":" + time.Minute + " ");
            builder.Append(errorText);
            lock (_errorLock)
            {
                File.AppendAllText(errorFile, builder.ToString());
            }
        }
    }
}
