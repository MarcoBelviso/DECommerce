using DECommerce.Configuration.Models;
using DECommerce.Interfaces;
using DECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IDECommerceRepository _iDECommerceRepository;

        public ConfigurationsController(IDECommerceRepository idecommerceRepository)
        {
            _iDECommerceRepository = idecommerceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetConfigurations()
        {
            ActionResult result = null;
            try
            {
                Configurations configuration = null;
                result = null;

                try
                {
                    configuration = _iDECommerceRepository.GetConfiguration();
                    Configuration config = JsonConvert.DeserializeObject<Configuration>(configuration.Configuration);
                    result = Ok(config);

                }
                catch (Exception ex)
                {
                    result = StatusCode(StatusCodes.Status500InternalServerError,
                        $"Error while getting users {ex.Message}");
                }

                return result;
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                   $"Error while getting users {ex.Message} {ex.InnerException?.Message}");
            }
            return result;
        }
    }
}
