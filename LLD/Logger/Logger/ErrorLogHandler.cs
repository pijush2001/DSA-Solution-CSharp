using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public  class ErrorLogHandler :LogHandler
    {
        public ErrorLogHandler(LogHandler nextLogHandler) : base(nextLogHandler) { }

        override public void Log(int level, string message)
        {
            if (level == Error)
            {
                Console.WriteLine("Error: "+ message);
            }
            else
            {
                base.Log(level, message);
            }
        }
    }
}
