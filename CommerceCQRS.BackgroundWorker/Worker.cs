using CommerceCQRS.BackgroundWorker.Application.Interfaces;

namespace CommerceCQRS.BackgroundWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        public Worker(IServiceScopeFactory scopeFactory, ILogger<Worker> logger)
        {
            this._scopeFactory = scopeFactory;
            this._logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (this._logger.IsEnabled(LogLevel.Information))
                {
                    this._logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                using var scope = _scopeFactory.CreateScope();

                var processMessageService = scope.ServiceProvider.GetRequiredService<IProcessMessageService>();

                await processMessageService.ProcessAsync(stoppingToken);
            }
        }
    }
}
