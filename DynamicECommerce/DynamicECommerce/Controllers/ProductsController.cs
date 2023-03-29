using DECommerce.Interfaces;
using DECommerce.Models;
using DECommerce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Data.SqlClient;
using System.Security.Authentication;
using System.Text;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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


        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<Products>> AddProduct([FromForm] Products product, IFormCollection formData)
        {
            ActionResult result = null;

            try
            {
                if (product == null)
                {
                    result = BadRequest();
                }
                else
                {
                    //var product = new Products();

                    // Recupera i dati dell'immagine dal FormData
                    var image = formData.Files[0];

                    if (image.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            image.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            var base64String = Convert.ToBase64String(fileBytes);
                            product.Image = base64String;
                        }

                        //int productCategoriesId = int.Parse(formData["productCategoriesId"]);
                        //ProductCategories productCategory = _idecommerceRepository.GetProductsCategoriesbyId(productCategoriesId);
                        //product.ProductCategoriesID = productCategory.ProductCategoriesID;

                        //decimal price = decimal.Parse(formData["unitPrice"]);
                        //product.UnitPrice = (int)price;

                    }
                    if (_idecommerceRepository.CreateProducts(product))
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
                     $"Error creating new Product record. {ex.Message}. Inner Exception: {ex.InnerException?.Message}");

            }

            return result;
        }

        [HttpGet, DisableRequestSizeLimit]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            IEnumerable<Products> products = new List<Products>();
            ActionResult result = null;
            try
            {
                products = _idecommerceRepository.GetProducts();

                foreach (var product in products)
                {
                    if (!string.IsNullOrEmpty(product.Image))
                    {
                        byte[] imageBytes = Convert.FromBase64String(product.Image);
                        string imageSrc = Convert.ToBase64String(imageBytes);
                        product.Image = imageSrc;
                    }
                }

                result = Ok(products);
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting Products {ex.Message} inner: {ex.InnerException}");
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
