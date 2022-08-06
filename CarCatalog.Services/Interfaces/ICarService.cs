using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CarCatalog.Domain.Models;

namespace CarCatalog.Services.Interfaces
{
    public interface ICarService
    {
        Task<CarDto> Create(CarDto carEntity, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<CarDto> Get(int id, CancellationToken cancellationToken);
        Task<IEnumerable<CarDto>> GetCars(CancellationToken cancellationToken);
        Task<bool> Update(int id, CarDto carEntity, CancellationToken cancellationToken);
    }
}