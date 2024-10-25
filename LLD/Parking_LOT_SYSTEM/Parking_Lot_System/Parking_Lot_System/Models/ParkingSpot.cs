using Parking_Lot_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot_System.Models
{

    public abstract class ParkingSpot : IParkingSpot
    {
        public int Id { get; set; }
        public bool IsReserved { get; set; }
        public int RowNumber { get; set; }
        public int DistanceFromEntry { get; set; }
        public int Level { get; set; }

        public void Reserve()
        {
            IsReserved = true;
        }

        public void Vacate()
        {
            IsReserved = false;
        }
    }

    public class CarParkingSpot : ParkingSpot { }

    public class HandicapParkingSpot : ParkingSpot { }

    public class MotorcycleParkingSpot : ParkingSpot { }

}
