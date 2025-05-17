using CommerceCQRS.BackgroundWorker.Application.Interfaces;
using CommerceCQRS.Services.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace CommerceCQRS.BackgroundWorker.Infrastructure
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;

        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<OutboxMessage?> GetUnprocessedAsync(CancellationToken cancellationToken)
        {
            return _context.OutboxMessages
                .Where(m => m.ProcessedOnUtc == null &&
                            (m.LockedUntilUtc == null || m.LockedUntilUtc < DateTime.Now))
                .OrderBy(m => m.OccurredOn)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> TryLockMessageAsync(Guid messageId, CancellationToken cancellationToken)
        {
            var affected = await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"
            UPDATE OutboxMessages
            SET LockedUntilUtc = DATEADD(minute, 5, GETUTCDATE())
            WHERE Id = {messageId} AND (LockedUntilUtc IS NULL OR LockedUntilUtc < GETUTCDATE())",
                cancellationToken);

            return affected == 1;
        }

        public async Task MarkAsProcessedAsync(Guid messageId, CancellationToken cancellationToken)
        {
            var message = await _context.OutboxMessages.FindAsync(new object[] { messageId }, cancellationToken);
            if (message is not null)
            {
                message.ProcessedOnUtc = DateTime.UtcNow;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
