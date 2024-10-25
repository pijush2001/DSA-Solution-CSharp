using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot_System.Interfaces
{
    public interface IParkingSpot
    {
        int Id { get; set; }
        bool IsReserved { get; set; }
        int RowNumber { get; set; }
        int DistanceFromEntry { get; set; }
        int Level { get; set; }
        
        void Reserve();
        void Vacate();
    }
}
