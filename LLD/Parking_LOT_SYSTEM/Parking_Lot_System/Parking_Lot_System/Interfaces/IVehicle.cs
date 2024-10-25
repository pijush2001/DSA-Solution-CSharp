using Parking_Lot_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot_System.Interfaces
{
    public interface IVehicle
    {
        int Id { get; set; }
        string LicensePlate { get; set; }
        string CustomerId { get; set; }
        Terminal TerminalEntrance { get; set; }
        string Type { get; }
    }
}
