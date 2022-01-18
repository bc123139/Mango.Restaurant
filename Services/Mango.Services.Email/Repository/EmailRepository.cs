using Mango.Services.Email.Database;
using Mango.Services.Email.Database.Entities;
using Mango.Services.Email.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mango.Services.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<DatabaseContext> _dbContext;

        public EmailRepository(DbContextOptions<DatabaseContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SendAndLogEmail(UpdatePaymentResultMessage message)
        {
            //implement an email sender or call some other class library
            EmailLog emailLog = new EmailLog()
            {
                Email = message.Email,
                EmailSent = DateTime.Now,
                Log = $"Order - {message.OrderId} has been created successfully."
            };

            await using var _db = new DatabaseContext(_dbContext);
            _db.EmailLogs.Add(emailLog);
            await _db.SaveChangesAsync();
        }
    }
}
