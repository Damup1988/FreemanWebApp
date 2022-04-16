using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        
        public DataContext(DbContextOptions<DataContext> opts) : base(opts)
        {
            
        }
    }
}