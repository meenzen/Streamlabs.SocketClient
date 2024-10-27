[![GitHub](https://img.shields.io/github/license/meenzen/Streamlabs.SocketClient.svg)](https://github.com/meenzen/Streamlabs.SocketClient/blob/main/LICENSE)
[![codecov](https://codecov.io/gh/meenzen/Streamlabs.SocketClient/graph/badge.svg?token=OCF8O5TR2I)](https://codecov.io/gh/meenzen/Streamlabs.SocketClient)
[![NuGet](https://img.shields.io/nuget/v/Streamlabs.SocketClient.svg)](https://www.nuget.org/packages/Streamlabs.SocketClient)
[![NuGet](https://img.shields.io/nuget/dt/Streamlabs.SocketClient.svg)](https://www.nuget.org/packages/Streamlabs.SocketClient)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fmeenzen%2FStreamlabs.SocketClient.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Fmeenzen%2FStreamlabs.SocketClient?ref=badge_shield)

# Streamlabs.SocketClient

Unofficial C# client library for the Streamlabs socket API. Allows you to receive events from Streamlabs in real-time.

## Installation

```bash
dotnet add package Streamlabs.SocketClient
```

If you use Dependency Injection, you can use the [Streamlabs.SocketClient.Extensions](https://www.nuget.org/packages/Streamlabs.SocketClient.Extensions) package for easier setup.

```bash
dotnet add package Streamlabs.SocketClient.Extensions
```

```csharp
// provide the token directly
builder.Services.AddStreamlabsClient(options => options.Token = "store your token somewhere safe");

// or use a configuration section
builder.Services.AddStreamlabsClient(configuration.GetSection("Streamlabs"));

// automatically connect and disconnect the client
builder.Services.AddHostedService<StreamlabsStartStopWorker>();

// get the client via DI and use it
var client = serviceProvider.GetRequiredService<IStreamlabsClient>();
client.OnDonation += (sender, message) => Console.WriteLine($"Donation Received: {message.FormattedAmount}");
```

## Usage

First, you'll need to grab your `Socket API Token` from the [Streamlabs Dashboard](https://streamlabs.com/dashboard/settings/api-settings).

Open the Dashboard, then navigate to `Avatar Menu` → `Account Settings` → `API Settings` → `API Tokens`.
You will find the token in the field `Your Socket API Token`.

Now you're ready to set up the client. These examples show how to set up the client and listen for events:

- [Basic Example](https://github.com/meenzen/Streamlabs.SocketClient/tree/main/src/Streamlabs.SocketClient.Example/Program.cs)
- [Advanced Example (Worker Service with DI)](https://github.com/meenzen/Streamlabs.SocketClient/tree/main/src/Streamlabs.SocketClient.AdvancedExample)

## Contributing

Pull requests are welcome. Please use [Conventional Commits](https://www.conventionalcommits.org/) to keep
commit messages consistent.

When reporting bugs, please include the raw JSON payload of the event that caused the issue. You can find it attached to
the error message or by enabling debug logging and looking for `Streamlabs: Event received - [json]`.
Alternatively, you can use the [Event Capture](https://github.com/meenzen/Streamlabs.SocketClient/tree/main/src/Streamlabs.EventCapture)
tool to capture events and save them to a file.

## Acknowledgements

- [Streamlabs API Documentation](https://dev.streamlabs.com/docs/socket-api)
- [SocketIOClient](https://github.com/doghappy/socket.io-client-csharp) by [@doghappy](https://github.com/doghappy) is a great library for working with SocketIO servers in C#.
- [Streamlabs-Events-Receiver](https://github.com/ocgineer/Streamlabs-Events-Receiver) by [@ocgineer](https://github.com/ocgineer) is a similar project that served as inspiration for this one.

## License

Distributed under the [MIT License](https://choosealicense.com/licenses/mit/). See `LICENSE` for more information.


[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fmeenzen%2FStreamlabs.SocketClient.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Fmeenzen%2FStreamlabs.SocketClient?ref=badge_large)
