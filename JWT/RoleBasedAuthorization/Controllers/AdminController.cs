using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthorization.Models;

namespace RoleBasedAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("assign-roles")]
        public async Task<IActionResult> AssignRoles()
        {
            var user = await _userManager.FindByEmailAsync("dev@example.com");
            await _userManager.AddToRoleAsync(user, "Developer");

            var manager = await _userManager.FindByEmailAsync("manager@example.com");
            await _userManager.AddToRoleAsync(manager, "Manager");

            var client = await _userManager.FindByEmailAsync("client@example.com");
            await _userManager.AddToRoleAsync(client, "Client");

            return Ok("Roles assigned successfully");
        }
    }
}
