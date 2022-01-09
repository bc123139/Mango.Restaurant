using Mango.Services.CouponAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
