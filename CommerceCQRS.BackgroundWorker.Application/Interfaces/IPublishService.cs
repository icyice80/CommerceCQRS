using CommerceCQRS.Services.Shared.Messaging;

namespace CommerceCQRS.BackgroundWorker.Application.Interfaces
{
    public interface IPublishService
    {
        Task PublishAsync(OutboxMessage message, CancellationToken cancellationToken);
    }
}
