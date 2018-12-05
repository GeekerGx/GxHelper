using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GxHelper.FileBase.LogHelper
{
    public class LogHelper
    {
        private LogState logState { get; set; }

        private LogHelper(LogState logState)
        {
            this.logState = logState;
        }
        private void Write(string message)
        {
            DateTime dt = DateTime.Now;
            StringBuilder sbMessage = new StringBuilder();
            sbMessage.AppendFormat("{0,-10}{1,-10}{2}",
                dt.ToString("HH:mm:ss"),
                logState.ToString(),
                message);
            var logFile = new FileHelper(FileBaes.GetLogPath, dt.ToString("yyyy-MM-dd") + ".txt");
            logFile.Write(sbMessage.ToString());
        }
        public static void Debug(string message)
        {
            LogHelper log = new LogHelper(LogState.Debug);
            log.Write(message);
        }
        public static void Error(string message)
        {
            LogHelper log = new LogHelper(LogState.Error);
            log.Write(message);
        }
        public static void Info(string message)
        {
            LogHelper log = new LogHelper(LogState.Info);
            log.Write(message);
        }
    }
}
