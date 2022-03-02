using CustomerApi.Interfaces;
using CustomerApi.Models;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomer _customerService;

        public CustomersController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task Post([FromBody] Customer custromer)
        {
            await _customerService.AddCustomer(custromer);
        }
 
    }
}
