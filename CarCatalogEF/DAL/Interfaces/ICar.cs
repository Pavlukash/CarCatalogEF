using System.Collections.Generic;
using System.Threading.Tasks;
using CarCatalogEntityFramework.Models;

namespace CarCatalogEntityFramework.DAL.Interfaces
{
    public interface ICar
    {
        Task<Car> Create(Car car);
        Task Delete(int id);
        Task<Car> Get(int id);
        Task<IEnumerable<Car>> GetCars();
        Task Update(int id, Car car);
    }
}