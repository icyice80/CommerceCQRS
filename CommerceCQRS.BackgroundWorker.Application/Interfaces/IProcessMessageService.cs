namespace CommerceCQRS.BackgroundWorker.Application.Interfaces
{
    public interface IProcessMessageService
    {
        Task ProcessAsync(CancellationToken stoppingToken);
    }
}
