using System.ComponentModel.DataAnnotations;

namespace CarCatalogEntityFramework.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        
        public int CarId { get; set; }
        public Car Car { get; set; }

        [Required]
        [MaxLength(20)] 
        public string FirstName { get; set; } 
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}