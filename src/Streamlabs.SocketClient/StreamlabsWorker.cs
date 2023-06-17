using Microsoft.Extensions.Hosting;

namespace Streamlabs.SocketClient;

/// <summary>
/// Automatically starts and stops the <see cref="IStreamlabsClient"/> together with the host.
/// </summary>
public sealed class StreamlabsWorker : IHostedService
{
    private readonly IStreamlabsClient _client;

    public StreamlabsWorker(IStreamlabsClient client)
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
