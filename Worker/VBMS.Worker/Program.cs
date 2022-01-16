using VBMS.Infrastructure.Extensions;
using VBMS.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddDatabase(context.Configuration);
        services.AddInfrastructureServices();
    })
    .Build();

await host.RunAsync();
