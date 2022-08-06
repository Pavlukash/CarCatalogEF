using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarCatalog.Domain.Contexts;
using CarCatalog.Domain.Entities;
using CarCatalog.Domain.Models;
using CarCatalog.Services.Interfaces;
using CarCatalog.Services.Mappers;
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

        public async Task<IEnumerable<CarDto>> GetCars(CancellationToken cancellationToken)
        {
            var cars = await CarCatalogContext.Cars
                .AsNoTracking()
                .Select(x => x.ToDto())
                .ToListAsync(cancellationToken);
            
            return cars;
        }

        public async Task<CarDto> Get(int id, CancellationToken cancellationToken)
        {
            var car = await CarCatalogContext.Cars
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (car == null)
            {
                throw new Exception();
            }

            var result = car.ToDto();

            return result;
        }

        public async Task<CarDto> Create(CarDto newCarEntity, CancellationToken cancellationToken)
        {
            ValidateCreateRequest(newCarEntity);
            
            var newEntity = new CarEntity
            {
                Brand = newCarEntity.Brand,
                Model = newCarEntity.Model,
                CarType = newCarEntity.CarType,
                Setup = newCarEntity.Setup,
                Price = newCarEntity.Price 
            };
            
            CarCatalogContext.Cars.Add(newEntity);
            await CarCatalogContext.SaveChangesAsync(cancellationToken);

            var result = newEntity.ToDto();
            
            return result;
        }

        public async Task<bool> Update(int id, CarDto carEntity, CancellationToken cancellationToken)
        {
            var carToUpdate = await CarCatalogContext.Cars
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            
            if (carToUpdate == null)
            {
                throw new Exception();
            }

            carToUpdate.Brand = carEntity.Brand ?? carToUpdate.Brand;
            carToUpdate.Model = carEntity.Model ??  carToUpdate.Model;
            carToUpdate.CarType = carEntity.CarType ?? carToUpdate.CarType;
            carToUpdate.Setup = carEntity.Setup ?? carToUpdate.Setup;
            carToUpdate.Price = carEntity.Price ?? carToUpdate.Price;
            
             await CarCatalogContext.SaveChangesAsync(cancellationToken);

             return true;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var carToDelete = await CarCatalogContext.Cars
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            
            CarCatalogContext.Cars.Remove(carToDelete);
            await CarCatalogContext.SaveChangesAsync(cancellationToken);
            
            return true;
        }
        
        private void ValidateCreateRequest(CarDto data)
        {
            if (string.IsNullOrWhiteSpace(data.Brand)
                || string.IsNullOrWhiteSpace(data.Model))
            {
                throw new ArgumentException();
            }
        }
    }
}
