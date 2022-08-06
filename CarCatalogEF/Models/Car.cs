using System.ComponentModel.DataAnnotations;
using CarCatalogEntityFramework.Enums;

namespace CarCatalogEntityFramework.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Brand { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        
        [Required]
        public BodyStyleType CarType { get; set; }
        public SetupType Setup { get; set; }
        public decimal Price { get; set; }
    }
}