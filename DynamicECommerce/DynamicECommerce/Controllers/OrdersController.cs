using DECommerce.Interfaces;
using DECommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IDECommerceRepository _idecommerceRepository;

        public OrdersController(IDECommerceRepository idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Orders>> CreateOrders(Orders orders)
        {
            ActionResult result = null;
            try
            {
                if (orders == null)
                {
                    result = BadRequest();
                }
                else
                {
                    int orderID = _idecommerceRepository.CreateOrders(orders);
                    if (orderID > 0)
                    {
                        result = Ok(orderID);
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategories>>> Get()
        {
            IEnumerable<Orders> orders = new List<Orders>();
            ActionResult result = null;
            try
            {
                orders = _idecommerceRepository.GetOrders();
                result = Ok(orders);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }

        [HttpDelete("{OrdersID}")]
        public async Task<ActionResult<Orders>> DeleteOrders(int OrderID)
        {
            ActionResult result = null;
            try
            {
                if (OrderID == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.DeleteOrders(OrderID))
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

        [HttpGet("OrdersID{ID}")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrdersID(int OrderID)
        {
            Orders orders = new Orders();
            ActionResult result = null;
            try
            {
                orders = _idecommerceRepository.GetOrdersByID(OrderID);
                result = Ok(orders);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }

        [HttpGet("{UserID}")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrdersByUsersID()
        {
            IEnumerable<Orders> orders = new List<Orders>();
            ActionResult result = null;
            try
            {
                orders = _idecommerceRepository.GetOrdersByUserID();
                result = Ok(orders);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }
    }
}
