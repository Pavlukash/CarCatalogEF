using System.Threading.Tasks;
using CarCatalog.Domain.Entities;
using CarCatalog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalogEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICarService CarService { get; }

        public CarController(ICarService carService)
        {
            CarService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var result = await CarService.GetCars();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var car = await CarService.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Сreate([FromBody] CarEntity carEntity)
        {
            var newCar = await CarService.Create(carEntity);
            return Ok(newCar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CarEntity carEntity)
        {
            await CarService.Update(id, carEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await CarService.Delete(id);
            return NoContent();
        }
    }
}