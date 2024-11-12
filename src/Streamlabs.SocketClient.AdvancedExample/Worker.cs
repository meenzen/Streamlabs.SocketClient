using System.Diagnostics.CodeAnalysis;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient.AdvancedExample;

public class Worker(ILogger<Worker> logger, IStreamlabsClient client) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // The client supports lots of events. We'll listen for donations in this example.
        client.OnDonation += OnDonation;
        logger.LogInformation("Listening for donations...");
        return Task.CompletedTask;
    }

    [SuppressMessage("Major Code Smell", "S1172:Unused method parameters should be removed")]
    private void OnDonation(object? _, DonationMessage message)
    {
        // As you can see, messages are strongly typed and provide all the data you need.
        logger.LogInformation("Donation: {User} donated {Amount}", message.Name, message.FormattedAmount);
    }
}
