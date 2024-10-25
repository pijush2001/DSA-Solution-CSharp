using Shuttle_Ride_Sharing_Application.Models;

namespace Shuttle_Ride_Sharing_Application.Repositories
{
    public class CabRepository:ICabRepository
    {
        private readonly List<Cab> _cabs = new();

        public void Add(Cab cab)
        {
            _cabs.Add(cab);

        }

        public Cab GetById(int id)
        {
            return _cabs.FirstOrDefault(r => r.Id == id);
        }

        public void Update(Cab cab)
        {
            Cab ride1 = GetById(cab.Id);
            if (cab != null)
            {
                _cabs.Remove(ride1);
                _cabs.Add(cab);
            }
        }
    }
}
