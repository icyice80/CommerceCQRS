using CommerceCQRS.BackgroundWorker.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CommerceCQRS.BackgroundWorker.Application
{
    /// <summary>
    /// The process does not guarantee the message will be published and updated only once.
    /// if published successfully, then failed on saving
    /// need to handle that on the consumers' side or failed on saving then save to somewhere
    /// another process will handle this after the message got consumed.
    /// </summary>
    public class ProcessMessageService : IProcessMessageService
    {
        private readonly ILogger<ProcessMessageService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;


        public ProcessMessageService( IServiceScopeFactory scopeFactory,ILogger<ProcessMessageService> logger)
        {
       
            this._scopeFactory = scopeFactory;
            this._logger = logger;
        }

        public async Task ProcessAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                try
                {
                    using var scope = this._scopeFactory.CreateScope();

                    var repo = scope.ServiceProvider.GetRequiredService<IMessageRepository>();
                    var publisher = scope.ServiceProvider.GetRequiredService<IPublishService>();


                    var message = await repo.GetUnprocessedAsync(stoppingToken);
                    if (message == null)
                    {
                        continue;
                    }

                    var locked = await repo.TryLockMessageAsync(message.Id, stoppingToken);
                    if (!locked) continue;

                    await publisher.PublishAsync(message, stoppingToken);
                    await repo.MarkAsProcessedAsync(message.Id, stoppingToken);

                }
                catch (Exception exception)
                {
                    _logger.LogError(exception, "Error in Processing outbox message.");
                    await Task.Delay(2000, stoppingToken);
                }
            }

        }
    }
}
