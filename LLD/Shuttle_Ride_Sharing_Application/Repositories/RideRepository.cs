using Shuttle_Ride_Sharing_Application.Models;

namespace Shuttle_Ride_Sharing_Application.Repositories
{
    public class RideRepository : IRideRepository
    {
        private readonly List<Ride> _rides = new();
        public void Add(Ride ride)
        {
            _rides.Add(ride);
            
        }

        public Ride GetById(int id)
        {
            return _rides.FirstOrDefault(r => r.Id == id);
        }

        public void Update(Ride ride)
        {
            Ride ride1 = GetById(ride.Id);
            if(ride != null)
            {
                _rides.Remove(ride1);
                _rides.Add(ride);
            }
        }

        public List<Ride> SearchByDestination(string destination)
        {
            return _rides.Where(r => r.Destination == destination && r.Status == RideStatus.InProgress).ToList();
        }
    }
}
