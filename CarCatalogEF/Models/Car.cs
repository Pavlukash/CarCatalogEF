using CarCatalogEntityFramework.Enums;

namespace CarCatalogEntityFramework.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public BodyStyleType CarType { get; set; }
        public SetupType Setup { get; set; }
        public decimal Price { get; set; }
    }
}