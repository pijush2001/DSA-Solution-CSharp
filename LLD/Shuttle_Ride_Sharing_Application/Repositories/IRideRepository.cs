using Shuttle_Ride_Sharing_Application.Models;

namespace Shuttle_Ride_Sharing_Application.Repositories
{
    public interface IRideRepository
    {
        void Add(Ride ride);
        void Update(Ride ride);
        Ride GetById(int id);
        List<Ride> SearchByDestination(string destination);
        // Additional methods
    }
}
