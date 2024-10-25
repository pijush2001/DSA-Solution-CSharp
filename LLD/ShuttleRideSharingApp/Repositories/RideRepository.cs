using ShuttleRideSharingApp.Models;

namespace ShuttleRideSharingApp.Repositories
{
    public interface IRideRepository
    {
        List<Ride> GetAllRides();
        Ride GetRideById(int id);
        void AddRide(Ride ride);
    }

    public class RideRepository : IRideRepository
    {
        private readonly List<Ride> _rides = new List<Ride>();

        public List<Ride> GetAllRides() => _rides;

        public Ride GetRideById(int id) => _rides.FirstOrDefault(r => r.Id == id);

        public void AddRide(Ride ride)
        {
            ride.Id = _rides.Count + 1;
            _rides.Add(ride);
        }
    }
}
