using CommerceCQRS.BackgroundWorker;
using CommerceCQRS.BackgroundWorker.Application;
using CommerceCQRS.BackgroundWorker.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);
ConfigureServices(builder);

var host = builder.Build();
host.Run();

void ConfigureServices(HostApplicationBuilder builder)
{
    // Add services to the container.
    builder.Services.AddHostedService<Worker>();
    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructureServices(builder.Configuration);
}