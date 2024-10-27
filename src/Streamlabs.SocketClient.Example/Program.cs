using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Streamlabs.SocketClient;

// Use "Microsoft.Extensions.Logging.Console" to get some nice console output.
// You could also use a NullLogger if you don't want the client to log anything.
// NullLoggerFactory.Instance.CreateLogger<StreamlabsClient>()
using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddSimpleConsole());
var logger = factory.CreateLogger<Program>();

var options = new OptionsWrapper<StreamlabsOptions>(
    new StreamlabsOptions { Token = "store your token somewhere safe" }
);
var client = new StreamlabsClient(factory.CreateLogger<StreamlabsClient>(), options);

// The client supports lots of events. We'll listen for donations in this example.
client.OnDonation += (_, message) =>
    // As you can see, messages are strongly typed and provide all the data you need.
    logger.LogInformation("Donation: {User} donated {Amount}", message.Name, message.FormattedAmount);

// Now we can connect and start listening for events.
await client.ConnectAsync();

logger.LogInformation("Listening for events. Press any key to exit.");
Console.ReadKey();

// While not strictly required, it's a good idea to properly disconnect when you're done.
await client.DisconnectAsync();
