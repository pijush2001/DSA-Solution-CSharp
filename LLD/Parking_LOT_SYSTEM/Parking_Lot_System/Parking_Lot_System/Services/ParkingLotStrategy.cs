using Parking_Lot_System.Interfaces;
using Parking_Lot_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot_System.Services
{
    public class ParkingLotStrategy
    {
        private readonly List<IParkingSpot> parkingSpots;
        private readonly ParkingLotEntranceStrategy entranceStrategy;

        public ParkingLotStrategy(List<IParkingSpot> spots)
        {
            this.parkingSpots = spots;
            this.entranceStrategy = new ParkingLotEntranceStrategy(spots);
        }

        public void Park(IParkingSpot spot, IVehicle vehicle, Terminal terminal)
        {
            spot.Reserve();
            // Additional implementation
        }

        public void Leave(IParkingSpot spot, IVehicle vehicle, Terminal terminal)
        {
            spot.Vacate();
            // Additional implementation
        }

        public List<IParkingSpot> AvailableSpots()
        {
            return parkingSpots.Where(spot => !spot.IsReserved).ToList();
        }

        public int CalculateHoursParked(ParkingTicket ticket)
        {
            return (DateTime.Now - ticket.ParkTime).Hours;
        }

        public IParkingSpot FindMostSuitableSpot(IVehicle vehicle, EntryTerminal terminal)
        {
            return entranceStrategy.FindMostSuitableSpot(vehicle, terminal);
        }
    }
}
