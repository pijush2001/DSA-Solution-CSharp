using Shuttle_Ride_Sharing_Application.Models;

namespace Shuttle_Ride_Sharing_Application.Services
{
    public interface IRideService
    {
        void CreateRide(Ride ride);
        bool BookRide(int rideId, Rider rider, int seatsRequired, string destination);
        void UpdateRideStatus(int rideId, RideStatus status);
        double CalculateAmount(Ride ride);
        Ride GetRideById(int rideId);
        bool IsRideValidForNewRider(int rideId, string destination);
        List<Ride> SearchRides(string destination);
        
    }
}
