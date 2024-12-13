using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Login> Login { get; set; }

        public DbSet<UserForm> UserForm { get; set; }
    }
}
