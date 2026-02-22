using Microsoft.Extensions.Hosting;

namespace Streamlabs.SocketClient.Extensions;

/// <summary>
/// Automatically connects and disconnects the <see cref="IStreamlabsClient"/> together with the application.
/// </summary>
public sealed class StreamlabsStartStopWorker(IStreamlabsClient client) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken) => await client.ConnectAsync();

    public async Task StopAsync(CancellationToken cancellationToken) => await client.DisconnectAsync();
}
