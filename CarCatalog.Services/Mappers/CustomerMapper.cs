using CarCatalog.Domain.Entities;
using CarCatalog.Domain.Models;

namespace CarCatalog.Services.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDto ToDto(this CustomerEntity entity)
        {
            var result = new CustomerDto
            {
                Id = entity.Id,
                CarId = entity.CarId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber
            };

            return result;
        }
    }
}