using Mango.Services.OrderAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.OrderAPI.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
