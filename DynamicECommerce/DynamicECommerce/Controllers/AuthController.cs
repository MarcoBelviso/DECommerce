using DECommerce.Interfaces;
using DECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IDECommerceRepository _dynamicEcommerceRepo;

        public AuthController(IDECommerceRepository repository)
        {
            _dynamicEcommerceRepo = repository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Users user)
        {
            var storedUser = _dynamicEcommerceRepo.GetUserByUsername(user.Username);

            if (storedUser == null || storedUser.Password != user.Password)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("zKlsBLU0Zr92JeKiQjzal9bVPvDnbUytCfFvz95uGsiSjvlioT9CG4FoMMdh0mpzH76RkG2v0hZyqz4deBlCQm9ppOqAsB14SqxvdZG2SUYf8OEfdajmfLcgyK1SDqyxMvuCZw90COYZtd8ZDjXXrjeOpTVV4HbfkomokQZHdN1XblBfSIviRQyDzCnZEf3xYiBiy6k4e0466IAGq0slnNBBPOLaeKysssGU7XSchXeIH7SzNjHU6SFZsohmGy6exNyRgz8euTCuIqj5POQAR41Dpc82RfXBak4mgk8xd9OpW0x7a1HEfWplnFWEqIPN0pgGrvKdONHi9OhraIDeMiWhUMAOuEJDCAFxoZNhV8R1LgitDLSXweQYFqb6xDE3OBLR6e7z8YZSN1sF0ILbF38NInCBrUQbosi5OP2XhlUCqAIHTSekLrYZfrRqKiRDrNKLpwlgB8rIEIkpxwIWTSgZj0L23lLVMHWxJopwvFIVDH6Bjp5fRePv66FUslcl");

            if (storedUser != null)
            {
                var userRole = _dynamicEcommerceRepo.GetUserRoleByUserId(storedUser.UserID);
                if (userRole == null)
                {
                    // Gestire il caso in cui non esiste un UserRole per l'utente
                    return BadRequest("UserRole non trovato per l'utente");
                }

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, storedUser.UserID.ToString()),
                    new Claim(ClaimTypes.Name, storedUser.Username),
                    new Claim(ClaimTypes.Role, userRole.RoleID.ToString())
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Audience = "your_audience",
                    Issuer = "your_issuer",
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { token = tokenHandler.WriteToken(token), roleId = userRole.RoleID, userID = storedUser.UserID });
            }
            else
            {
                // Gestire il caso in cui storedUser è null
                return BadRequest("Utente non trovato");
            }
        }
    }
}

