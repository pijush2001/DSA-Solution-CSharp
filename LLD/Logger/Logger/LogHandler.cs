using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class LogHandler
    {
        public static int Info = 1;
        public static int Debug = 2;
        public static int Warning = 3;
        public static int Error = 4;
        public static int Fatal = 5;
        
        LogHandler nextLogHandler;
        public LogHandler(LogHandler logHandler)
        {
            this.nextLogHandler = logHandler;
        }

        virtual public void Log(int logLevel, string message)
        {
            if (nextLogHandler != null)
            {
                nextLogHandler.Log(logLevel, message);
            }
        }
    }
}
