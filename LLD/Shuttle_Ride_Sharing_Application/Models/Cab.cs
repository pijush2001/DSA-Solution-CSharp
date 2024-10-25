namespace Shuttle_Ride_Sharing_Application.Models
{
    public class Cab
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public Driver Driver { get; set; }
        public int MaxSeats { get; set; } // Maximum number of seats
        public bool IsAvailable { get; set; } // Availability status
        // Additional properties
    }
}
