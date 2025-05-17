using CommerceCQRS.Services.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace CommerceCQRS.BackgroundWorker.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<OutboxMessage> OutboxMessages { get; set; } = null!;

        public AppDbContext(DbContextOptions options) : base(options) { }

    }
}
