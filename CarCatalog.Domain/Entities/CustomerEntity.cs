using System.ComponentModel.DataAnnotations;

namespace CarCatalog.Domain.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }
        public int? CarId { get; set; }

        [Required] 
        [MaxLength(20)] 
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = null!;
        
        [MaxLength(20)]
        public string? PhoneNumber { get; set; } 
        
        public CarEntity? CarEntity { get; set; }
    }
}