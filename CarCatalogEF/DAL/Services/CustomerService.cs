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
    public class CustomerService : ICustomer
    {
        private ApplicationContext _db { get; }

        public CustomerService(ApplicationContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _db.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> Get(int id)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return customer;
        }

        public async Task<Customer> Create(Customer newCustomer)
        {
            _db.Customers.Add(newCustomer);
            await _db.SaveChangesAsync();
            return newCustomer;
        }

        public async Task Update(int id, Customer customer)
        {
            var customerToUpdate = await _db.Customers
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (customerToUpdate == null)
            {
                throw new Exception();
            }

            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.Email = customer.Email;
            customerToUpdate.PhoneNumber = customer.PhoneNumber;
            
            await _db.SaveChangesAsync();
        }

        public async Task ChangeCarId(int id, Customer customer)
        {
            var customerToUpdate = await _db.Customers
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (customerToUpdate == null)
            {
                throw new Exception();
            }

            customerToUpdate.CarId = customer.CarId;
            
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var customerToDelete = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            _db.Customers.Remove(customerToDelete);
            await _db.SaveChangesAsync();
        }
    }
}