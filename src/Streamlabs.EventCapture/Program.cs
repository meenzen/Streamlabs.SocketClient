using Streamlabs.SocketClient;
using System.Globalization;
using System.Text;
using System.Text.Json.Nodes;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(
        (context, services) =>
        {
            services.AddStreamlabsClient(context.Configuration.GetRequiredSection("Streamlabs"));
            services.AddHostedService<StreamlabsWorker>();
        }
    )
    .Build();

string directory = Directory.CreateDirectory("events").FullName;
ILogger<Program> logger = host.Services.GetRequiredService<ILogger<Program>>();

host.Services.GetRequiredService<IStreamlabsClient>().OnEventRaw += (sender, json) =>
{
    // [{"type":"foo", "data": "bar"}]

    JsonNode? node = JsonNode.Parse(json);

    if (node is null)
    {
        logger.LogWarning("Event is not valid JSON: {json}", json);
    }

    bool unexpected = false;
    int? count = node?.AsArray().Count;
    if (count is not 1)
    {
        unexpected = true;
        logger.LogWarning("Event has unexpected object count: {count} - {json}", count, json);
    }

    string? type = node?[0]?["type"]?.GetValue<string>();

    if (type is null)
    {
        logger.LogWarning("Event has no type: {json}", json);
        type = "unknown";
    }

    if (unexpected)
    {
        type = "unexpected";
    }

    string filename = $"{DateTime.UtcNow.ToString("yyyy-MM-ddTHH-mm-ss-fff", CultureInfo.InvariantCulture)}.json";
    string typeDirectory = Directory.CreateDirectory(Path.Combine(directory, type)).FullName;
    string path = Path.Combine(typeDirectory, filename);

    logger.LogInformation("Writing event: {{ type: \"{type}\", filename: \"{filename}\" }}", type, filename);

    File.WriteAllText(path, json, new UTF8Encoding());
};

host.Run();
