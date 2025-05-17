using CommerceCQRS.Services.Shared.Messaging;

namespace CommerceCQRS.BackgroundWorker.Application.Interfaces
{
    public interface IMessageRepository
    {
        Task<OutboxMessage?> GetUnprocessedAsync(CancellationToken cancellationToken);
        Task<bool> TryLockMessageAsync(Guid messageId, CancellationToken cancellationToken);
        Task MarkAsProcessedAsync(Guid messageId, CancellationToken cancellationToken);
    }
}
