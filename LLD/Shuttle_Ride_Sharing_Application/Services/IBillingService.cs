using Shuttle_Ride_Sharing_Application.Models;

namespace Shuttle_Ride_Sharing_Application.Services
{
    public interface IBillingService
    {
        double CalculateAmount(Ride ride);
    }
}
