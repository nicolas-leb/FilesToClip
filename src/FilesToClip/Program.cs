using FilesToClip;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.CommandLine;
using System.IO.Abstractions;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureHostConfiguration(configHost =>
    {
        configHost.SetBasePath(Directory.GetCurrentDirectory());
        configHost.AddJsonFile("appsettings.json", optional: false);
    })
    .ConfigureServices(services => 
    { 
        services.AddTransient<IFileSystem, FileSystem>();
        services.AddTransient<IFileContatenator, FileContatenator>();
        services.AddTransient<App>();
    })
    .UseSerilog((context, configuration) =>
    {
        configuration.ReadFrom.Configuration(context.Configuration);
    })
    .Build();

var app = host.Services.GetRequiredService<App>();
await app.RunAsync(args);

