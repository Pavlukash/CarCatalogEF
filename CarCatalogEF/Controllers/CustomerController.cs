using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CarCatalogEntityFramework.Models;
using CarCatalogEntityFramework.DAL.Interfaces;

namespace СarCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomer _repo { get; }

        public CustomerController(ICustomer repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _repo.GetCustomers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _repo.Get(id);
            
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Сreate([FromBody] Customer customer)
        {
            var newCustomer = await _repo.Create(customer);
            return Ok(newCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Customer customer)
        {
            await _repo.Update(id, customer);
            return NoContent();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeCarId(int id, Customer customer)
        {
            await _repo.ChangeCarId(id, customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Delete(id);
            return NoContent();
        }
    }
}