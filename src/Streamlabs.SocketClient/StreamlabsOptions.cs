namespace Streamlabs.SocketClient;

public sealed class StreamlabsOptions
{
    public string Url { get; set; } = "https://sockets.streamlabs.com";
    public string Token { get; set; } = string.Empty;
    public bool Reconnection { get; set; } = true;
}
