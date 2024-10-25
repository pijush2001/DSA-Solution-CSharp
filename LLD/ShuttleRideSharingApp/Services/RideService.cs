using ShuttleRideSharingApp.Models;
using ShuttleRideSharingApp.Repositories;

namespace ShuttleRideSharingApp.Services
{
    public interface IRideService
    {
        List<Ride> GetAllRides();
        Ride GetRideById(int id);
        void CreateRide(Ride ride);
    }

    public class RideService : IRideService
    {
        private readonly IRideRepository _rideRepository;

        public RideService(IRideRepository rideRepository)
        {
            _rideRepository = rideRepository;
        }

        public List<Ride> GetAllRides() => _rideRepository.GetAllRides();

        public Ride GetRideById(int id) => _rideRepository.GetRideById(id);

        public void CreateRide(Ride ride) => _rideRepository.AddRide(ride);
    }
}
