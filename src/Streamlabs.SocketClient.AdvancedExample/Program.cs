using Streamlabs.SocketClient.AdvancedExample;
using Streamlabs.SocketClient.Extensions;

var builder = Host.CreateApplicationBuilder(args);

// Configure the client. You can edit appsettings.json or use user secrets to provide the token.
// Alternatively the environment variable "Streamlabs__Token" can be used.
builder.Services.AddStreamlabsClient(builder.Configuration.GetSection("Streamlabs"));

// This included worker will connect to Streamlabs on startup.
// It will also gracefully disconnect on shutdown.
builder.Services.AddHostedService<StreamlabsStartStopWorker>();

// Our custom worker sets up event handlers for Streamlabs events.
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
await host.RunAsync();
