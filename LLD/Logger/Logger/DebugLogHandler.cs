using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class DebugLogHandler : LogHandler
    {
        public DebugLogHandler(LogHandler nextLogHandler) : base(nextLogHandler) { }

        override public void Log(int level, string message)
        {
            if(level == Debug)
            {
                Console.WriteLine("Debugg: " +message);
            }
            else { 
            base.Log(level, message);
            }
        }
    }
}
