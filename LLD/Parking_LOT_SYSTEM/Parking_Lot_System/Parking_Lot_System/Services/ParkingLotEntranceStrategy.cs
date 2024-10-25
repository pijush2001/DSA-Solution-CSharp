using Parking_Lot_System.Interfaces;
using Parking_Lot_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot_System.Services
{
    public class ParkingLotEntranceStrategy
    {
        private readonly SortedSet<ParkingSpotWithPriority> parkingSpots;

        public ParkingLotEntranceStrategy(List<IParkingSpot> spots)
        {
            // Initialize SortedSet with custom comparer to sort by priority
            parkingSpots = new SortedSet<ParkingSpotWithPriority>(new ParkingSpotComparer());

            // Add all parking spots to the SortedSet
            foreach (var spot in spots)
            {
                parkingSpots.Add(new ParkingSpotWithPriority(spot, CalculatePriority(spot)));
            }
        }

        public IParkingSpot FindMostSuitableSpot(IVehicle vehicle, EntryTerminal terminal)
        {
            // Return the first available and suitable parking spot
            return parkingSpots.FirstOrDefault(spot => !spot.Spot.IsReserved && IsSuitableForVehicle(spot.Spot, vehicle))?.Spot;
        }

        private bool IsSuitableForVehicle(IParkingSpot spot, IVehicle vehicle)
        {
            // Implement logic to check if the spot is suitable for the vehicle type
            // For example, a HandicapVehicle can only park in HandicapParkingSpot, etc.
            return spot.GetType().Name.StartsWith(vehicle.Type);
        }

        private int CalculatePriority(IParkingSpot spot)
        {
            // Implement logic to calculate the priority of the spot
            // For simplicity, we can use spot.Id as a priority (lower ID means higher priority)
            return spot.Id;
        }
    }

    public class ParkingSpotWithPriority
    {
        public IParkingSpot Spot { get; }
        public int Priority { get; }

        public ParkingSpotWithPriority(IParkingSpot spot, int priority)
        {
            Spot = spot;
            Priority = priority;
        }
    }

    public class ParkingSpotComparer : IComparer<ParkingSpotWithPriority>
    {
        public int Compare(ParkingSpotWithPriority x, ParkingSpotWithPriority y)
        {
            // Compare by priority first
            int priorityComparison = x.Priority.CompareTo(y.Priority);

            // If priorities are equal, compare by spot ID to ensure uniqueness
            return priorityComparison == 0 ? x.Spot.Id.CompareTo(y.Spot.Id) : priorityComparison;
        }
    }
}
