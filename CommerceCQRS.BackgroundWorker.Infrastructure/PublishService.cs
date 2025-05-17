using Azure.Messaging.ServiceBus;
using CommerceCQRS.BackgroundWorker.Application.Interfaces;
using CommerceCQRS.Services.Shared.Messaging;

namespace CommerceCQRS.BackgroundWorker.Infrastructure
{
    public class AzureServiceBusPublishService : IPublishService
    {
        private readonly ServiceBusClient _client;
        private readonly Lazy<ServiceBusSender> _lazySender;
        private const string TopicName = "outbox-message-topic-name";

        public AzureServiceBusPublishService(ServiceBusClient client)
        {
            this._client = client;
            this._lazySender = new Lazy<ServiceBusSender>(() => _client.CreateSender(TopicName));
        }
        public Task PublishAsync(OutboxMessage message, CancellationToken cancellationToken)
        {
            var serviceBusMessage = new ServiceBusMessage(message.Content)
            {
                MessageId = message.Id.ToString(),
                Subject = message.Type
            };

            return this._lazySender.Value.SendMessageAsync(serviceBusMessage, cancellationToken);
        }

    }
}
