using CommerceCQRS.Services.Shared.Domain;
using CommerceCQRS.Services.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CommerceCQRS.Cart.Write.Infrastructure
{
    public class CartDbContext : DbContext
    {
        public DbSet<OutboxMessage> OutboxMessages { get; set; } = null!;

        public DbSet<Domain.Cart> Carts { get; set; } = null!;
        public CartDbContext(DbContextOptions options) : base(options) { }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEntities = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IAggregateRoot root &&
                            root.DomainEvents.Any())
                .Select(e => (IAggregateRoot)e.Entity)
                .ToList();

            var domainEvents = domainEntities
                .SelectMany(e => e.DomainEvents)
                .ToList();

            foreach (var domainEvent in domainEvents)
            {
                var outboxMessage = new OutboxMessage
                {
                    Id = Guid.NewGuid(),
                    OccurredOn = domainEvent.OccurredOn,
                    Type = domainEvent.GetType().AssemblyQualifiedName!,
                    Content = JsonSerializer.Serialize(domainEvent),
                    Processed = false
                };
                OutboxMessages.Add(outboxMessage);
            }

            domainEntities.ForEach(e => e.ClearDomainEvents());

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
