using Microsoft.EntityFrameworkCore;
using CarCatalogEntityFramework.Models;

namespace CarCatalogEntityFramework.Contexts
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(b => b.Car)
                .WithOne(i => i.Customer)
                .HasForeignKey<Car>(b => b.CustomerId);
        }
    }
}