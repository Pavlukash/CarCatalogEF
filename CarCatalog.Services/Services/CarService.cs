using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarCatalog.Domain.Contexts;
using CarCatalog.Domain.Models;
using CarCatalog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Services.Services
{
    public class CarService : ICarService
    {
        private CarCatalogContext CarCatalogContext { get; }

        public CarService(CarCatalogContext context)
        {
            CarCatalogContext = context;
        }

        public async Task<IEnumerable<CarDto>> GetCars()
        {
            var cars = await CarCatalogContext.Cars.ToListAsync();
            
            return cars;
        }

        public async Task<CarDto> Get(int id)
        {
            var car = await CarCatalogContext.Cars.FirstOrDefaultAsync(x => x.Id == id);

            return car;
        }

        public async Task<CarDto> Create(CarDto newCarEntity)
        {
            CarCatalogContext.Cars.Add(newCarEntity);
            await CarCatalogContext.SaveChangesAsync();
            return newCarEntity;
        }

        public async Task<bool> Update(int id, CarDto carEntity)
        {
            var carToUpdate = await CarCatalogContext.Cars
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            
            if (carToUpdate == null)
            {
                throw new Exception();
            }

            carToUpdate.Brand = carEntity.Brand;
            carToUpdate.Model = carEntity.Model;
            carToUpdate.CarType = carEntity.CarType;
            carToUpdate.Setup = carEntity.Setup;
            carToUpdate.Price = carEntity.Price;
            
             await CarCatalogContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var carToDelete = await CarCatalogContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
            CarCatalogContext.Cars.Remove(carToDelete);
            await CarCatalogContext.SaveChangesAsync();
        }
    }
}
