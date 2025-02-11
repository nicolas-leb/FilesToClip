using FilesToClip;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.CommandLine;
using System.IO.Abstractions;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => 
    { 
        services.AddTransient<IFileSystem, FileSystem>();
        services.AddTransient<IFileContatenator, FileContatenator>();
        services.AddTransient<App>();
    })
    .Build();

var app = host.Services.GetRequiredService<App>();
await app.RunAsync(args);

