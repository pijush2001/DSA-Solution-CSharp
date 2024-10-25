namespace Shuttle_Ride_Sharing_Application.Models
{
    public class Ride
    {
        public int Id { get; set; }
        public Rider Rider { get; set; }
        public Driver Driver { get; set; }
        public Cab Cab { get; set; }

        public string StartingPoint { get; set; } // Starting point of the ride
        public string Destination { get; set; } // Ending point of the ride
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Seats { get; set; }
        public double Distance { get; set; }
        public double Amount { get; set; }
        public RideStatus Status { get; set; }
        // Additional properties
    }
    public enum RideStatus
    {
        Created,
        InProgress,
        Completed,
        Cancelled
    }
}
