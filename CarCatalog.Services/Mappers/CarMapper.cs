using CarCatalog.Domain.Entities;
using CarCatalog.Domain.Models;

namespace CarCatalog.Services.Mappers
{
    public static class CarMapper
    {
        public static CarDto ToDto(this CarEntity entity)
        {
            var result = new CarDto
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                Brand = entity.Brand,
                Model = entity.Model,
                CarType = entity.CarType,
                Setup = entity.Setup,
                Price = entity.Price
            };

            return result;
        }
    }
}