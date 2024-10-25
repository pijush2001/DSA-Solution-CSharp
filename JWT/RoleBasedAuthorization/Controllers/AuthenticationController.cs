using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RoleBasedAuthorization.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RoleBasedAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private static readonly List<string> roles = null;
       

        public AuthenticationController(IConfiguration configuration)
        {
            roles.Add(Role.Client);
            roles.Add(Role.Manager);
            roles.Add(Role.Developer);
            _configuration = configuration ;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {

            // This is just an example, in a real-world application you will validate user credentials from a database.
            if (login.UserName == "pijush" && login.Password == "password@pijush")
            {
                var user = new User { Name = login.UserName, Email = login.Password, role = login.Role };
                var token = GenerateJwtToken(user);
                return Ok(new { token });
            }

            return Unauthorized();
        }
        public  string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name)
            };
            /*foreach(var role in roles)
            {*/
                claims.Add(new Claim(ClaimTypes.Role, user.role));   
            //}
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: jwtSettings["Issuer"],
                                            audience: jwtSettings["Audience"],
                                            claims: claims,
                                            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationInMinutes"])),
                                            signingCredentials: creds);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
