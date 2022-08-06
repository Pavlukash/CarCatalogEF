using System.Threading;
using System.Threading.Tasks;
using CarCatalog.Domain.Models;
using CarCatalog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalogEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService CustomerService { get; }

        public CustomerController(ICustomerService customerService)
        {
            CustomerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
        {
            var result = await CustomerService.GetCustomers(cancellationToken);
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var customer = await CustomerService.Get(id, cancellationToken);

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Сreate([FromBody] CustomerDto customerEntity)
        {
            var newCustomer = await CustomerService.Create(customerEntity, CancellationToken.None);
            
            return Ok(newCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] CustomerDto customerEntity)
        {
            var result = await CustomerService.Update(id, customerEntity, CancellationToken.None);
            
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeCarId(int id,[FromQuery] int carId)
        {
            var result = await CustomerService.ChangeCustomersCar(id, carId, CancellationToken.None);
            
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await CustomerService.Delete(id, CancellationToken.None);
            
            return Ok(result);
        }
    }
}