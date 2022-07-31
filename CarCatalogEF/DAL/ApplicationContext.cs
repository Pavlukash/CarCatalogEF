using Microsoft.EntityFrameworkCore;
using CarCatalogEntityFramework.Models;

namespace CarCatalogEntityFramework.Contexts
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}