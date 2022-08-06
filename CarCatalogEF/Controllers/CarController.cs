using System.Threading;
using System.Threading.Tasks;
using CarCatalog.Domain.Models;
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
        public async Task<IActionResult> GetCars(CancellationToken cancellationToken)
        {
            var result = await CarService.GetCars(cancellationToken);
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var car = await CarService.Get(id, cancellationToken);

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Сreate([FromBody] CarDto carEntity)
        {
            var newCar = await CarService.Create(carEntity, CancellationToken.None);
            
            return Ok(newCar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] CarDto carEntity)
        {
            var result = await CarService.Update(id, carEntity, CancellationToken.None);
            
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await CarService.Delete(id, CancellationToken.None);
            
            return Ok(result);
        }
    }
}