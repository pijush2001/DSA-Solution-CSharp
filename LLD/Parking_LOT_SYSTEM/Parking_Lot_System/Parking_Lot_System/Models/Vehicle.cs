using Parking_Lot_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot_System.Models
{
    
        public class Car : IVehicle
        {
            public int Id { get; set; }
            public string LicensePlate { get; set; }
            public string CustomerId { get; set; }
            public Terminal TerminalEntrance { get; set; }
            public string Type => "Car";
        }

        public class HandicapVehicle : IVehicle
        {
            public int Id { get; set; }
            public string LicensePlate { get; set; }
            public string CustomerId { get; set; }
            public Terminal TerminalEntrance { get; set; }
            public string Type => "Handicap";
        }

        public class Motorcycle : IVehicle
        {
            public int Id { get; set; }
            public string LicensePlate { get; set; }
            public string CustomerId { get; set; }
            public Terminal TerminalEntrance { get; set; }
            public string Type => "Motorcycle";
        }
    

}
