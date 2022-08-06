using System.Collections.Generic;
using System.Threading.Tasks;
using CarCatalog.Domain.Models;

namespace CarCatalog.Services.Interfaces
{
    public interface ICarService
    {
        Task<CarDto> Create(CarDto carEntity);
        Task<bool> Delete(int id);
        Task<CarDto> Get(int id);
        Task<IEnumerable<CarDto>> GetCars();
        Task<bool> Update(int id, CarDto carEntity);
    }
}