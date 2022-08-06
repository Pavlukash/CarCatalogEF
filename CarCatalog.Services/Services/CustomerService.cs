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
    public class CustomerService : ICustomerService
    {
        private CarCatalogContext CarCatalogContext { get; }

        public CustomerService(CarCatalogContext context)
        {
            CarCatalogContext = context;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers(CancellationToken cancellationToken)
        {
            var customers = await CarCatalogContext.Customers
                .AsNoTracking()
                .Select(x => x.ToDto())
                .ToListAsync(cancellationToken);
            
            return customers;
        }

        public async Task<CustomerDto> Get(int id, CancellationToken cancellationToken)
        {
            var customer = await CarCatalogContext.Customers
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (customer == null)
            {
                throw new Exception();
            }

            var result = customer.ToDto();
            
            return result;
        }

        public async Task<CustomerDto> Create(CustomerDto newCustomerEntity, CancellationToken cancellationToken)
        {
            ValidateCreateRequest(newCustomerEntity);
            
            var newEntity = new CustomerEntity
            {
                CarId = newCustomerEntity.CarId,
                FirstName = newCustomerEntity.FirstName!,
                LastName = newCustomerEntity.LastName!,
                Email = newCustomerEntity.Email!,
                PhoneNumber = newCustomerEntity.PhoneNumber
            };

            CarCatalogContext.Customers.Add(newEntity);
            await CarCatalogContext.SaveChangesAsync(cancellationToken);

            var result = newEntity.ToDto();
            
            return result;
        }

        public async Task<bool> Update(int id, CustomerDto customerEntity, CancellationToken cancellationToken)
        {
            var customerToUpdate = await CarCatalogContext.Customers
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (customerToUpdate == null)
            {
                throw new Exception();
            }

            customerToUpdate.FirstName = customerEntity.FirstName ?? customerToUpdate.FirstName;
            customerToUpdate.LastName = customerEntity.LastName ?? customerToUpdate.LastName;
            customerToUpdate.Email = customerEntity.Email ?? customerToUpdate.Email;
            customerToUpdate.PhoneNumber = customerEntity.PhoneNumber ?? customerToUpdate.PhoneNumber;
            
            await CarCatalogContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> ChangeCustomersCar(int id,  int carId, CancellationToken cancellationToken)
        {
            var customerToUpdate = await CarCatalogContext.Customers
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (customerToUpdate == null)
            {
                throw new Exception();
            }

            var car = await CarCatalogContext.Cars
                .AsNoTracking()
                .Where(x => x.Id == carId)
                .FirstOrDefaultAsync();

            customerToUpdate.CarEntity = car ?? throw new Exception();
            
            await CarCatalogContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var customerToDelete = await CarCatalogContext.Customers
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            
            if (customerToDelete == null)
            {
                throw new Exception();
            }
            
            CarCatalogContext.Customers.Remove(customerToDelete);
            await CarCatalogContext.SaveChangesAsync(cancellationToken);
            
            return true;
        }

        private void ValidateCreateRequest(CustomerDto data)
        {
            if (string.IsNullOrWhiteSpace(data.FirstName)
               || string.IsNullOrWhiteSpace(data.LastName)
               || string.IsNullOrWhiteSpace(data.Email))
            {
                throw new ArgumentException();
            }
        }
    }
}