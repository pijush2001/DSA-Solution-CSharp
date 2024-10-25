using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleBasedAuthorization.Controllers
{
    [Authorize(Roles ="Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        [HttpGet("view-passwords")]
        public IActionResult ViewClientPasswords()
        {
            // Code for viewing client passwords
            return Ok("Client passwords for managers");
        }
    }
}
