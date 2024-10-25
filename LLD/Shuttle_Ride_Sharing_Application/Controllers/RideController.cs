using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shuttle_Ride_Sharing_Application.Models;
using Shuttle_Ride_Sharing_Application.Services;

namespace Shuttle_Ride_Sharing_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly IRideService _rideService;
        

        public RideController(IRideService rideService)
        {
            _rideService = rideService;
        }

        [HttpPost("create")]
        public IActionResult CreateRide([FromBody] Ride ride)
        {
            _rideService.CreateRide(ride);
            return Ok();
        }

        [HttpPost("book/{rideId}")]
        public IActionResult BookRide(int rideId, [FromBody] BookRideRequest request)
        {
            _rideService.BookRide(rideId, request.Rider, request.SeatsRequired, request.Destination); 
            return Ok();
        }

        [HttpPost("update/{rideId}")]
        public IActionResult UpdateRideStatus(int rideId, [FromBody] RideStatus status)
        {
            _rideService.UpdateRideStatus(rideId, status);
            return Ok();
        }

        [HttpGet("calculate/{rideId}")]
        public IActionResult CalculateAmount(int rideId)
        {
            var ride = _rideService.GetRideById(rideId);
            if (ride != null)
            {
                var amount = _rideService.CalculateAmount(ride);
                return Ok(amount);
            }
            return NotFound();
        }
        [HttpGet("validate/{rideId}/{destination}")]
        public IActionResult ValidateRide(int rideId, string destination)
        {
            var isValid = _rideService.IsRideValidForNewRider(rideId, destination);
            return Ok(isValid);
        }
        [HttpGet("searchRides")]
        public IActionResult SearchRides([FromQuery] string destination)
        {
            var rides = _rideService.SearchRides(destination);
            return Ok(rides);
        }
    }
}
