using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleBasedAuthorization.Controllers
{
    [Authorize(Roles = "Developer")]
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        // Developer-specific actions
        [HttpGet("view-status")]
        public IActionResult ViewClientStatus()
        {
            // Code for viewing client statuses
            return Ok("Client statuses for developers");
        }
    }
}
