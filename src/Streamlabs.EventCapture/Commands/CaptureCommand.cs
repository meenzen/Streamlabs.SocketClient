using System.Globalization;
using System.Text;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre.Console.Cli;
using Streamlabs.SocketClient;

namespace Streamlabs.EventCapture.Commands;

internal sealed class CaptureCommand : AsyncCommand, IDisposable
{
    private readonly DirectoryInfo _directory;
    private readonly IStreamlabsClient _client;
    private readonly ILogger<CaptureCommand> _logger;
    private CancellationTokenSource? _cancellationTokenSource;

    public CaptureCommand(DirectoryInfo directory, IStreamlabsClient client, ILogger<CaptureCommand> logger)
    {
        _directory = directory;
        _client = client;
        _logger = logger;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, CancellationToken cancellationToken)
    {
        _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cancellationToken = _cancellationTokenSource.Token;

        Console.CancelKeyPress += (sender, args) =>
        {
            args.Cancel = true;
            _cancellationTokenSource.Cancel();
        };

        await AnsiConsole
            .Status()
            .StartAsync(
                "Connecting to Streamlabs...",
                async ctx =>
                {
                    ctx.SpinnerStyle(Color.Blue);
                    ctx.Spinner(Spinner.Known.BouncingBar);

                    _client.OnEventRaw += (_, json) => ClientOnOnEventRaw(json);

                    await _client.ConnectAsync();

                    ctx.Status("Listening for events, press Ctrl+C to exit.");

                    try
                    {
                        await Task.Delay(-1, cancellationToken);
                    }
                    catch (TaskCanceledException)
                    {
                        // Ignore
                    }

                    _logger.LogInformation("Stopping...");

                    await _client.DisconnectAsync();
                }
            );

        return 0;
    }

    private void ClientOnOnEventRaw(string json)
    {
        // [{"type":"foo", "data": "bar"}]

        JsonNode? node = JsonNode.Parse(json);

        if (node is null)
        {
            _logger.LogWarning("Event is not valid JSON: {Json}", json);
        }

        bool unexpected = false;
        int? count = node?.AsArray().Count;
        if (count is not 1)
        {
            unexpected = true;
            _logger.LogWarning("Event has unexpected object count: {Count} - {Json}", count, json);
        }

        string? type = node?[0]?["type"]?.GetValue<string>();

        if (type is null)
        {
            _logger.LogWarning("Event has no type: {Json}", json);
            type = "unknown";
        }

        if (unexpected)
        {
            type = "unexpected";
        }

        string filename = $"{DateTime.UtcNow.ToString("yyyy-MM-ddTHH-mm-ss-fff", CultureInfo.InvariantCulture)}.json";
        string typeDirectory = Directory.CreateDirectory(Path.Combine(_directory.FullName, type)).FullName;
        string path = Path.Combine(typeDirectory, filename);

        _logger.LogInformation("Writing event: {{ type: \"{Type}\", filename: \"{Filename}\" }}", type, filename);

        File.WriteAllText(path, json, new UTF8Encoding());
    }

    public void Dispose()
    {
        _cancellationTokenSource?.Dispose();
        _client.Dispose();
    }
}
