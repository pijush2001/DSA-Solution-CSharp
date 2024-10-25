using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleBasedAuthorization.Controllers
{
    [Authorize(Roles = "Client")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet("view-application-status")]
        public IActionResult ViewApplicationStatus()
        {
            // Code for clients to view their application status
            return Ok("Your application status");
        }
    }
}
