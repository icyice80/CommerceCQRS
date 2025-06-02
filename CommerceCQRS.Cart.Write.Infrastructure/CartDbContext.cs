using CommerceCQRS.Services.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using CommerceCQRS.Services.Shared.Application;
using CommerceCQRS.Services.Shared.Messaging;
using CommerceCQRS.Cart.Write.Application.Translator;

namespace CommerceCQRS.Cart.Write.Infrastructure
{
    public class CartDbContext : DbContext, IUnitOfWork
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
                var integrationEvent = DomainEventMapper.ToIntegrationEvent(domainEvent);

                if (integrationEvent == null) continue; // Skip internal-only events

                var outboxMessage = new OutboxMessage
                {
                    Id = integrationEvent.EventId,
                    OccurredOn = integrationEvent.OccurredOnUtc,
                    Type = integrationEvent.GetType().AssemblyQualifiedName!,
                    Content = JsonSerializer.Serialize(integrationEvent),
                };
                OutboxMessages.Add(outboxMessage);
            }

            domainEntities.ForEach(e => e.ClearDomainEvents());

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
