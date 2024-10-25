using Parking_Lot_System.Interfaces;
using Parking_Lot_System.Models;
using Parking_Lot_System.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Parking Lot System");

        // Sample test
        //taking customer information
        EntryTerminal entryTerminal = new EntryTerminal(1, "North Entrance");
        IVehicle car = VehicleFactory.CreateVehicle("Car", 1, "ABC123", "CUST001", entryTerminal);

        ParkingTicket ticket = entryTerminal.GenerateTicket(car);

        Console.WriteLine($"Ticket generated for {car.Type} with ID: {ticket.Id} at {entryTerminal.Location}");

        // Initialize parking spots
        List<IParkingSpot> parkingSpots = new List<IParkingSpot> {
                new CarParkingSpot { Id = 1 },
                new HandicapParkingSpot { Id = 2 },
                new MotorcycleParkingSpot { Id = 3 }
            };

        ParkingLotStrategy parkingLotStrategy = new ParkingLotStrategy(parkingSpots);

        // Find the most suitable spot
        IParkingSpot suitableSpot = parkingLotStrategy.FindMostSuitableSpot(car, entryTerminal);

        if (suitableSpot != null)
        {
            parkingLotStrategy.Park(suitableSpot, car, entryTerminal);
            Console.WriteLine($"Car parked in spot ID: {suitableSpot.Id}");
        }
        else
        {
            Console.WriteLine("No suitable parking spot found.");
        }

        // Leaving the parking lot
        ExitTerminal exitTerminal = new ExitTerminal(2, "South Exit");
        parkingLotStrategy.Leave(suitableSpot, car, exitTerminal);

        Console.WriteLine($"Car left from spot ID: {suitableSpot.Id}");
    }
}