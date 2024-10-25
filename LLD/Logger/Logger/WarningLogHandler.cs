using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logger
{
    public  class WarningLogHandler:LogHandler
    {
        public WarningLogHandler(LogHandler nextLogHandler) : base(nextLogHandler) { }

        override public void Log(int level, string message)
        {
            if (level == Warning)
            {
                Console.WriteLine("Warning: " + message);
            }
            else
            {
                base.Log(level, message);
            }
        }
    }
}
