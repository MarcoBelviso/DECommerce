using DECommerce.Interfaces;
using DECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DECommerce.Repository;
using Microsoft.AspNetCore.Authorization;

namespace DynamicECommerce.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IDECommerceRepository _idecommerceRepository;

        public UsersController(IDECommerceRepository idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }

        //------------------------------------------------------------------//Metodi CRUD
        
        [HttpPost]
        public async Task<ActionResult<Users>> AddUser([FromBody] Users user)
        {
            ActionResult result = null;
            try
            {
                if (user == null)
                {
                    result = BadRequest();
                }
                else
                {
                    Roles role = _idecommerceRepository.GetRoleById(2);
                    if (_idecommerceRepository.CreateUsers(user))
                    {
                        UserRole userRole = new UserRole { UserID = user.UserID, RoleID = role.RoleID };
                        if (_idecommerceRepository.AddUserRole(userRole))
                        {
                            result = Ok();
                        }
                        else
                        {
                            result = StatusCode(StatusCodes.Status500InternalServerError);
                        }
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
                    $"Error creating new user record {ex.Message}");
            }

            return result;
        }
        [Authorize(Roles="1")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            

            IEnumerable<Users> users = new List<Users>();
            ActionResult result = null;

            try
            {
                users = _idecommerceRepository.GetUsers();
                result = Ok(users);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }

        [Authorize]
        [HttpGet("UserID{ID}")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUserId(int UserID)
        {
            Users user = new Users();
            ActionResult result = null;
            try
            {
                user = _idecommerceRepository.GetUserByID(UserID);
                result = Ok(user);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }

        [Authorize (Roles="2")]
        [HttpDelete("{UserID}")]
        public async Task<ActionResult<Users>> DeleteUsers(int UserID)
        {
            ActionResult result = null;
            try
            {
                if (UserID == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.DeleteUsers(UserID))
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
                    $"Error getting users {ex.Message}");
            }

            return result;
        }


        [HttpGet("{username}")]
        public async Task<ActionResult<Users>> GetUserByUsername(string username)
        {
            Users user = null;
            ActionResult result = null;

            try
            {
                user = _idecommerceRepository.GetUserByUsername(username);
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
