using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarCatalogEntityFramework.Models;
using CarCatalogEntityFramework.DAL.Interfaces;
using CarCatalogEntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;


namespace CarCatalogEntityFramework.Services
{
    public class CarService : ICar
    {
        private ApplicationContext _db { get; }

        public CarService(ApplicationContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            var cars = await _db.Cars.ToListAsync();
            return cars;
        }

        public async Task<Car> Get(int id)
        {
            var car = await _db.Cars.FirstOrDefaultAsync(x => x.Id == id);
            return car;
        }

        public async Task<Car> Create(Car newCar)
        {
            _db.Cars.Add(newCar);
            await _db.SaveChangesAsync();
            return newCar;
        }

        public async Task Update(int id, Car car)
        {
            var carToUpdate = await _db.Cars
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            
            if (carToUpdate == null)
            {
                throw new Exception();
            }

            carToUpdate.Brand = car.Brand;
            carToUpdate.Model = car.Model;
            carToUpdate.CarType = car.CarType;
            carToUpdate.Setup = car.Setup;
            carToUpdate.Price = car.Price;
            
             await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var carToDelete = await _db.Cars.FirstOrDefaultAsync(x => x.Id == id);
            _db.Cars.Remove(carToDelete);
            await _db.SaveChangesAsync();
        }
    }
}
