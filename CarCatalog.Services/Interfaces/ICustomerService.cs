using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CarCatalog.Domain.Models;

namespace CarCatalog.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto> Create(CustomerDto data, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<CustomerDto> Get(int id, CancellationToken cancellationToken);
        Task<IEnumerable<CustomerDto>> GetCustomers(CancellationToken cancellationToken);
        Task<bool> Update(int id, CustomerDto customerEntity, CancellationToken cancellationToken);
        Task<bool> ChangeCustomersCar(int id, int carId, CancellationToken cancellationToken);
    }
}