using Shuttle_Ride_Sharing_Application.Models;

namespace Shuttle_Ride_Sharing_Application.Services
{
    public class BillingService : IBillingService
    {
        private readonly double _amountPerKm;
        public BillingService(double amountPerKm)
        {
            _amountPerKm = amountPerKm;
        }

        public double CalculateAmount(Ride ride)
        {
            return ride.Seats == 1 ?
            ride.Distance * _amountPerKm :
            ride.Distance * ride.Seats * 0.75 * _amountPerKm;//giving 25% discount when more than one seats are booked together
        }
    }
}
