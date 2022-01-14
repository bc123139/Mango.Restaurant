using Mango.Services.OrderAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.OrderAPI.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
