using Mango.Services.Email.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.Email.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<EmailLog> EmailLogs { get; set; }
    }
}
