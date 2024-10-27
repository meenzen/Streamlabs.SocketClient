using Microsoft.Extensions.Hosting;

namespace Streamlabs.SocketClient.Extensions;

/// <summary>
/// Automatically connects and disconnects the <see cref="IStreamlabsClient"/> together with the application.
/// </summary>
public sealed class StreamlabsStartStopWorker : IHostedService
{
    private readonly IStreamlabsClient _client;

    public StreamlabsStartStopWorker(IStreamlabsClient client)
    {
        _client = client;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _client.ConnectAsync();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _client.DisconnectAsync();
    }
}
