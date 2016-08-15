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

        static Logger()
        {
            File.WriteAllText(logFile, $"Log file created {DateTime.Now} \n");
            File.WriteAllText(errorFile, $"Error log created {DateTime.Now} \n");
        }

        public static void Log(string logText)
        {
            var time = System.DateTime.Now;
            var builder = new StringBuilder();
            builder.Append(time.Hour + ":" + time.Minute + " ");
            builder.Append(logText + Environment.NewLine);
            lock (_logLock)
            {
                File.AppendAllText(logFile, builder.ToString());
            }
        }

        public static void Log(BHangMessage message)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(message.Command);
            if (message.Value != null)
                builder.Append(" " + message.Value);
            if (message.ExtraValues != null)
                foreach (var item in message.ExtraValues)
                {
                    if (item != null)
                        builder.Append(" " + item);
                }
            Log(builder.ToString());
        }
        public static void Error(string errorText)
        {
            var time = System.DateTime.Now;
            var builder = new StringBuilder();
            builder.Append(time.Hour + ":" + time.Minute + " ");
            builder.Append(errorText + Environment.NewLine);
            lock (_errorLock)
            {
                File.AppendAllText(errorFile, builder.ToString());
            }
        }
    }
}
