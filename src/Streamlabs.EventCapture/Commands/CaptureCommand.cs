using System.Globalization;
using System.Text;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre.Console.Cli;
using Streamlabs.SocketClient;

namespace Streamlabs.EventCapture.Commands;

internal sealed class CaptureCommand(DirectoryInfo directory, IStreamlabsClient client, ILogger<CaptureCommand> logger)
    : AsyncCommand,
        IDisposable
{
    private CancellationTokenSource? _cancellationTokenSource;

    protected override async Task<int> ExecuteAsync(CommandContext context, CancellationToken cancellationToken)
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

                    client.OnEventRaw += (_, json) => ClientOnOnEventRaw(json);

                    await client.ConnectAsync();

                    ctx.Status("Listening for events, press Ctrl+C to exit.");

                    try
                    {
                        await Task.Delay(-1, cancellationToken);
                    }
                    catch (TaskCanceledException)
                    {
                        // Ignore
                    }

                    logger.LogInformation("Stopping...");

                    await client.DisconnectAsync();
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
            logger.LogWarning("Event is not valid JSON: {Json}", json);
        }

        var unexpected = false;
        int? count = node?.AsArray().Count;
        if (count is not 1)
        {
            unexpected = true;
            logger.LogWarning("Event has unexpected object count: {Count} - {Json}", count, json);
        }

        string? type = node?[0]?["type"]?.GetValue<string>();

        if (type is null)
        {
            logger.LogWarning("Event has no type: {Json}", json);
            type = "unknown";
        }

        if (unexpected)
        {
            type = "unexpected";
        }

        var filename = $"{DateTime.UtcNow.ToString("yyyy-MM-ddTHH-mm-ss-fff", CultureInfo.InvariantCulture)}.json";
        var typeDirectory = Directory.CreateDirectory(Path.Combine(directory.FullName, type)).FullName;
        var path = Path.Combine(typeDirectory, filename);

        logger.LogInformation("Writing event: {{ type: \"{Type}\", filename: \"{Filename}\" }}", type, filename);

        File.WriteAllText(path, json, new UTF8Encoding());
    }

    public void Dispose()
    {
        _cancellationTokenSource?.Dispose();
        client.Dispose();
    }
}
