using DECommerce.Interfaces;
using DECommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private IDECommerceRepository _idecommerceRepository;

        public OrderDetailsController(IDECommerceRepository idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> Get()
        {
            IEnumerable<OrderDetails> orderDetails = new List<OrderDetails>();
            ActionResult result = null;
            try
            {
                orderDetails = _idecommerceRepository.GetOrderDetails();
                result = Ok(orderDetails);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }

        [HttpGet("OrderDetailsID{ID}")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetailsID(int OrderDetailsID)
        {
            OrderDetails orderDetails = new OrderDetails();
            ActionResult result = null;
            try
            {
                orderDetails = _idecommerceRepository.GetOrderDetailsByID(OrderDetailsID);
                result = Ok(orderDetails);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }

        [HttpGet("OrderID{ID}")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrdeDetailByOrderID(int OrderID)
        {
            IEnumerable<OrderDetails> orderDetails = new List<OrderDetails>();
            ActionResult result = null;
            try
            {
                orderDetails = _idecommerceRepository.GetOrderDetailsByOrderID(OrderID);
                result = Ok(orderDetails);

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
