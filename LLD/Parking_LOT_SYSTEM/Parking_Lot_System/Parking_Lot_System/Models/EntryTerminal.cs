using Parking_Lot_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot_System.Models
{
    public class EntryTerminal : Terminal
    {
        public EntryTerminal(int terminalId, string location) : base(terminalId, location)
        {
        }
        public ParkingTicket GenerateTicket(IVehicle vehicle)
        {
            var ticket = new ParkingTicket
            {
                Id = new Random().Next(1000, 9999),
                ParkingSpotId = 0, // Placeholder, will be assigned during parking
                IssueTime = DateTime.Now,
                ParkTime = DateTime.Now
            };
            return ticket;
        }
    }
}
