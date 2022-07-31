using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CarCatalogEntityFramework.Models;
using CarCatalogEntityFramework.DAL.Interfaces;

namespace СarCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICar _repo { get; }

        public CarController(ICar repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var result = await _repo.GetCars();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var car = await _repo.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Сreate([FromBody] Car car)
        {
            var newCar = await _repo.Create(car);
            return Ok(newCar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Car car)
        {
            await _repo.Update(id, car);
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