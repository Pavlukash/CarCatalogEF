namespace CarCatalog.Domain.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}