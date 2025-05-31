using CommerceCQRS.BackgroundWorker.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CommerceCQRS.BackgroundWorker.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProcessMessageService, ProcessMessageService>();
        }
    }
}
