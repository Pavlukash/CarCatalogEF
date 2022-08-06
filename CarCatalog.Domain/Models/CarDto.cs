using CarCatalog.Domain.Enums;

namespace CarCatalog.Domain.Models
{
    public class CarDto
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public BodyStyleType? CarType { get; set; }
        public SetupType? Setup { get; set; }
        public decimal? Price { get; set; }
    }
}