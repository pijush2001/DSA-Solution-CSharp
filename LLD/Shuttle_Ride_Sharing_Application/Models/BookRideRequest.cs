namespace Shuttle_Ride_Sharing_Application.Models
{
    public class BookRideRequest
    {
        public Rider Rider { get; set; }
        public int SeatsRequired { get; set; }
        public string Destination {  get; set; }
    }
}
