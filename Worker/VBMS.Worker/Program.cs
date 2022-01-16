



IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingletonDatabase(context.Configuration);
        services.AddWorkerServices();
        services.AddHostedService<LoanBackgroundService>();
    })
    .Build();

await host.RunAsync();
