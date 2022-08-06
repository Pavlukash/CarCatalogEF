using System.ComponentModel.DataAnnotations;
using CarCatalog.Domain.Enums;

namespace CarCatalog.Domain.Entities
{
    public class CarEntity
    {
        [Key]
        public int Id { get; set; }
        public int? CustomerId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Brand { get; set; } = null!;
        
        [Required]
        [MaxLength(20)]
        public string Model { get; set; } = null!;
        
        [Required]
        public BodyStyleType CarType { get; set; } 
        public SetupType Setup { get; set; } 
        public decimal Price { get; set; } 
        
        public CustomerEntity? CustomerEntity { get; set; }
    }
}