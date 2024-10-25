using Shuttle_Ride_Sharing_Application.Models;
using Shuttle_Ride_Sharing_Application.Repositories;

namespace Shuttle_Ride_Sharing_Application.Services
{
    public class RideService : IRideService
    {
        public readonly IRideRepository rideRepository;
        public readonly IBillingService billingService;
        public readonly ICabRepository cabRepository;

        public RideService(IRideRepository rideRepository, IBillingService billingService, ICabRepository cabRepository)
        {
            this.rideRepository = rideRepository;
            this.billingService = billingService;
            this.cabRepository = cabRepository;
        }




        public bool BookRide(int rideId, Rider rider, int seatsRequired, string destnation)
        {
            var ride = rideRepository.GetById(rideId);
            if (ride != null && ride.Cab.MaxSeats >= seatsRequired 
                && ride.Destination.Trim().ToUpper() == destnation.Trim().ToUpper()
                && ride.Cab.IsAvailable)
            {
                ride.Rider = rider;
                ride.Seats += seatsRequired;
                ride.Cab.MaxSeats -= seatsRequired; // Reduce available seats
                rideRepository.Update(ride);
                return true;
            }
            else
            {
                return false;

            }
        }

        public double CalculateAmount(Ride ride)
        {
            return billingService.CalculateAmount(ride);


        }

        public void CreateRide(Ride ride)
        {
            if (!string.IsNullOrEmpty(ride.StartingPoint) && !string.IsNullOrEmpty(ride.Destination))
            {
                ride.Driver = ride.Cab.Driver;
                ride.Cab.IsAvailable = false;
                rideRepository.Add(ride);
            }
        }


        public void UpdateRideStatus(int rideId, RideStatus status)
        {
            var ride = rideRepository.GetById(rideId);
            if (ride != null)
            {
                ride.Status = status;
                rideRepository.Update(ride);
            }
        }
        public Ride GetRideById(int rideId)
        {
            return rideRepository.GetById(rideId);
        }
        public bool IsRideValidForNewRider(int rideId, string destination)
        {
            var ride = rideRepository.GetById(rideId);
            return ride != null && ride.Destination == destination && ride.Status == RideStatus.InProgress;
        }
        public bool IsCabAvailable(int cabId)
        {
            var cab = cabRepository.GetById(cabId);
            return cab != null && cab.IsAvailable;
        }

        public List<Ride> SearchRides(string destination)
        {
            return rideRepository.SearchByDestination(destination);
        }

    }
}
