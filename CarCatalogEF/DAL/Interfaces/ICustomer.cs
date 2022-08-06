using System.Collections.Generic;
using System.Threading.Tasks;
using CarCatalogEntityFramework.Models;

namespace CarCatalogEntityFramework.DAL.Interfaces
{
    public interface ICustomer
    {
        Task<Customer> Create(Customer customer);
        Task Delete(int id);
        Task<Customer> Get(int id);
        Task<IEnumerable<Customer>> GetCustomers();
        Task Update(int id, Customer customer);
        Task ChangeCarId(int id, Customer customer);
    }
}