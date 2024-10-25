using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class InfoLogHandler: LogHandler
    {
     
        public InfoLogHandler(LogHandler nextLogHandler) : base(nextLogHandler) { }

       override public void Log(int level, string message)
        {
           if(level == Info)
            {
                Console.WriteLine("Info: "+ message);
            }
            else
            {
                base.Log(level, message);
            }
        }
    }
}
