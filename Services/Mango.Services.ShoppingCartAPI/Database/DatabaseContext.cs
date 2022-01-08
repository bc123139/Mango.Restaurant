using Mango.Services.ShoppingCartAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ShoppingCartAPI.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
    }
}
