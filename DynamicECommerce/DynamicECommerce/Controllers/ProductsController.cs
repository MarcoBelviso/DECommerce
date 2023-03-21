using DECommerce.Interfaces;
using DECommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IDECommerceRepository _idecommerceRepository;

        public ProductsController(IDECommerceRepository idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }

        [Authorize(Roles="1")]
        [HttpPost]
        public async Task<ActionResult<Products>> CreateProducts(Products products)
        {
            ActionResult result = null;
            try
            {
                if (products == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.CreateProducts(products))
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> Get()
        {
            IEnumerable<Products> products = new List<Products>();
            ActionResult result = null;
            try
            {
                products = _idecommerceRepository.GetProducts();
                result = Ok(products);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }

        [HttpGet("ProductID{ID}")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductId(int ProductID)
        {
            Products products = new Products();
            ActionResult result = null;
            try
            {
                products = _idecommerceRepository.GetProductByID(ProductID);
                result = Ok(products);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }

        [Authorize(Roles="1")]
        [HttpDelete("{ProductID}")]
        public async Task<ActionResult<Products>> DeleteProducts(int ProductID)
        {
            ActionResult result = null;
            try
            {
                if (ProductID == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.DeleteProducts(ProductID))
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

        [HttpGet("ProductCategoriesID{ID}")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductByCategoryID(int ProductCategoriesID)
        {
            IEnumerable<Products> products = new List<Products>();
            ActionResult result = null;
            try
            {
                products = _idecommerceRepository.GetProductsByCategoriesID(ProductCategoriesID);
                result = Ok(products);

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
