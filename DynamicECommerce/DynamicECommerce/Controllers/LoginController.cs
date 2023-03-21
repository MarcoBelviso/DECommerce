using DECommerce.Interfaces;
using DECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IDECommerceRepository _dynamicEcommerceRepo;
        public LoginController(IDECommerceRepository dynamicEcommerceRepo)
        {
            _dynamicEcommerceRepo = dynamicEcommerceRepo;
        }

        //GET:api/Users/Username
        [HttpGet("{username}")]
        public async Task<ActionResult<Users>> GetUserByUsername(string username)
        {
            Users user = null;
            ActionResult result = null;

            try
            {
                user = _dynamicEcommerceRepo.GetUserByUsername(username);
                if (user == null)
                {
                    result = NotFound($"User with id {username} not found.");
                }
                else
                {
                    result = Ok(user);
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error getting user {ex.Message}");
            }

            return result;
        }


    }
}

