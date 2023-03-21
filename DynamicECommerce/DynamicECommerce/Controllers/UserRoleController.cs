using DECommerce.Interfaces;
using DECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private IDECommerceRepository _idecommerceRepository;

        public UserRoleController(IDECommerceRepository idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> Get()
        {
            IEnumerable<UserRole> userRole = new List<UserRole>();
            ActionResult result = null;
            try
            {
                userRole = _idecommerceRepository.GetUserRole();
                result = Ok(userRole);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }

        [HttpGet("{UserByUserRole}")]
        public async Task<ActionResult<UserRole>> GetUserRoleByUserId(int UserID)
        {
            UserRole userRole = null;
            ActionResult result = null;

            try
            {
                userRole = _idecommerceRepository.GetUserRoleByUserId(UserID);
                if (userRole == null)
                {
                    result = NotFound($"User Role with UserID {UserID} not found.");
                }
                else
                {
                    result = Ok(userRole);
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error getting User Role {ex.Message}");
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<UserRole>> AddUserRole(UserRole userRole)
        {
            ActionResult result = null;
            try
            {
                if (userRole == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.AddUserRole(userRole))
                    {
                        result = Ok();
                    }
                    else
                    {
                        result = StatusCode(StatusCodes.Status500InternalServerError);
                    }
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error creating new UserRole record {ex.Message}");
            }

            return result;
        }
    }
}
