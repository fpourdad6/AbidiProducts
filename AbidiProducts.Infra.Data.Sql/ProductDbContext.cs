using Microsoft.EntityFrameworkCore;

namespace AbidiProducts.Models
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
