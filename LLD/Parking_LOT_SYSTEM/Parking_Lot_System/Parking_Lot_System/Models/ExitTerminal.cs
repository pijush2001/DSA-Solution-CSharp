using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot_System.Models
{
    public class ExitTerminal : Terminal
    {
        public ExitTerminal(int terminalId, string location) : base(terminalId, location)
        {
        }
        public void AcceptTicket(ParkingTicket ticket)
        {
            // Implementation for ticket validation and processing
        }
    }
}
