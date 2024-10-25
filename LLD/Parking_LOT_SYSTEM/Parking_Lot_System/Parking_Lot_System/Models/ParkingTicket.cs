using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot_System.Models
{
    public class ParkingTicket
    {
        public int Id { get; set; }
        public int ParkingSpotId { get; set; }
        public DateTime IssueTime { get; set; }
        public DateTime ParkTime { get; set; }
    }
}
