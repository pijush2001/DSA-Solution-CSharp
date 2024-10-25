namespace ShuttleRideSharingApp.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Cab Cab { get; set; }
    }

    public class Cab
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public int NumberOfSeats { get; set; }
    }

    public class Rider
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Ride
    {
        public int Id { get; set; }
        public Driver Driver { get; set; }
        public List<Rider> Riders { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public int NumberOfSeats { get; set; }
        public double Cost { get; set; }
        public RideStatus Status { get; set; }
    }

    public enum RideStatus
    {
        Created,
        InProgress,
        Completed
    }

}
