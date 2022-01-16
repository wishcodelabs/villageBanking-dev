



IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingletonDatabase(context.Configuration);
        services.AddWorkerServices();
        services.AddHostedService<LoanDueDatesService>();

    })
    .Build();

await host.RunAsync();
