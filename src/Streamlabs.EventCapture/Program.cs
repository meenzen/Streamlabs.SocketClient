using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;
using SpectreConsoleLogger;
using Streamlabs.EventCapture.Commands;
using Streamlabs.EventCapture.Infrastructure;
using Streamlabs.SocketClient.Extensions;

DirectoryInfo directory = Directory.CreateDirectory("events");

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables()
    .Build();

var services = new ServiceCollection();

services.AddStreamlabsClient(configuration.GetSection("Streamlabs"));
services.AddLogging(builder => builder.AddSpectreConsole());
services.AddSingleton(directory);
services.AddSingleton<CaptureCommand>();

var app = new CommandApp<CaptureCommand>(new TypeRegistrar(services));

app.Configure(config =>
{
    config.SetApplicationName("Streamlabs Event Capture");
    config.Settings.ExceptionHandler = exception =>
    {
        AnsiConsole.WriteException(exception);
        return 1;
    };
    config.AddCommand<CaptureCommand>("capture");
});

return await app.RunAsync(args);
