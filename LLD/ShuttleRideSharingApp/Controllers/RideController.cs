using Microsoft.AspNetCore.Mvc;
using ShuttleRideSharingApp.Models;
using ShuttleRideSharingApp.Services;

namespace ShuttleRideSharingApp.Controllers
{
    public class RideController : Controller
    {
        private readonly IRideService _rideService;
        private readonly IDriverService _driverService;

        public RideController(IRideService rideService, IDriverService driverService)
        {
            _rideService = rideService;
            _driverService = driverService;
        }

        public IActionResult Index()
        {
            var rides = _rideService.GetAllRides();
            return View(rides);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Drivers = _driverService.GetAllDrivers();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ride ride)
        {
            _rideService.CreateRide(ride);
            return RedirectToAction("Index");
        }

        public IActionResult Book(int id)
        {
            var ride = _rideService.GetRideById(id);
            if (ride != null)
            {
                return View(ride);
            }

            return NotFound();
        }
    }
}
