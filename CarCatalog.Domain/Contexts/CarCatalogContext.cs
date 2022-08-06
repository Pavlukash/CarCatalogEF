using CarCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Domain.Contexts
{
    public sealed class CarCatalogContext : DbContext
    {
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public CarCatalogContext(DbContextOptions<CarCatalogContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>()
                .HasOne(b => b.CarEntity)
                .WithOne(i => i.CustomerEntity)
                .HasForeignKey<CarEntity>(b => b.CustomerId);
        }
    }
}