using DECommerce.Interfaces;
using DECommerce.Models;
using DECommerce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private IDECommerceRepository _idecommerceRepository;

        public ProductCategoriesController(IDECommerceRepository idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }
        
        [HttpPost]
        public async Task<ActionResult<ProductCategories>> CreateProductCategories(ProductCategories productCategories)
        {
            ActionResult result = null;
            try
            {
                if (productCategories == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.CreateProductCategories(productCategories))
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
        public async Task<ActionResult<IEnumerable<ProductCategories>>> Get()
        {
            IEnumerable<ProductCategories> productCategories = new List<ProductCategories>();
            ActionResult result = null;
            try
            {
                productCategories = _idecommerceRepository.GetProductCategories();
                result = Ok(productCategories);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }

        [HttpDelete("{ProductCategoriesID}")]
        public async Task<ActionResult<ProductCategories>> DeleteProductCategories(int ProductCategoriesID)
        {
            ActionResult result = null;
            try
            {
                if (ProductCategoriesID == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.DeleteUsers(ProductCategoriesID))
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


        [HttpGet("ProductCategories{ID}")]
        public async Task<ActionResult<IEnumerable<ProductCategories>>> GetProductsCategoriesbyId(int ProductCategoriesID)
        {
            ProductCategories ProductCategories = new ProductCategories();
            ActionResult result = null;
            try
            {
                ProductCategories = _idecommerceRepository.GetProductsCategoriesbyId(ProductCategoriesID);
                result = Ok(ProductCategories);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting BankAccounts {ex.Message}");
            }

            return result;
        }
    }


}
