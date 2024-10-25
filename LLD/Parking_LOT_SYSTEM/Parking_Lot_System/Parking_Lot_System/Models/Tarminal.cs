using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot_System.Models
{
    public abstract class Terminal
    {
        public int TerminalId { get; set; }
        public string Location { get; set; }

        // Constructor to initialize common properties
        protected Terminal(int terminalId, string location)
        {
            TerminalId = terminalId;
            Location = location;
        }
    }
}
