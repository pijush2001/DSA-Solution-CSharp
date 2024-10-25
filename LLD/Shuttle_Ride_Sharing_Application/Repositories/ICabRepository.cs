using Shuttle_Ride_Sharing_Application.Models;

namespace Shuttle_Ride_Sharing_Application.Repositories
{
    public interface ICabRepository
    {
        void Add(Cab cab);
        Cab GetById(int id);
        void Update(Cab cab);
    }
}
