[![GitHub](https://img.shields.io/github/license/meenzen/Streamlabs.SocketClient.svg)](https://github.com/meenzen/Streamlabs.SocketClient/blob/main/LICENSE)
[![codecov](https://codecov.io/gh/meenzen/Streamlabs.SocketClient/graph/badge.svg?token=OCF8O5TR2I)](https://codecov.io/gh/meenzen/Streamlabs.SocketClient)
[![NuGet](https://img.shields.io/nuget/v/Streamlabs.SocketClient.svg)](https://www.nuget.org/packages/Streamlabs.SocketClient)
[![NuGet](https://img.shields.io/nuget/dt/Streamlabs.SocketClient.svg)](https://www.nuget.org/packages/Streamlabs.SocketClient)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fmeenzen%2FStreamlabs.SocketClient.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Fmeenzen%2FStreamlabs.SocketClient?ref=badge_shield)

# Streamlabs.SocketClient

Unofficial C# client library for the Streamlabs socket API. Allows you to receive events from Streamlabs in real-time.

## Installation

This library is not ready for general use yet. Alpha releases are available on NuGet, but the API should not be considered stable until version 1.0.0.

```bash
dotnet add package Streamlabs.SocketClient --prerelease
```

If you use Dependency Injection, you can use the [Streamlabs.SocketClient.Extensions](https://www.nuget.org/packages/Streamlabs.SocketClient.Extensions) package for easier setup.

```bash
dotnet add package Streamlabs.SocketClient.Extensions --prerelease
```

```csharp
// provide the token directly
builder.Services.AddStreamlabsClient(options => options.Token = "store your token somewhere safe");

// or use a configuration section
builder.Services.AddStreamlabsClient(configuration.GetSection("Streamlabs"));

// automatically start and stop the client with the application
builder.Services.AddHostedService<StreamlabsStartStopWorker>();
```

## Usage

Step-by-step instructions will be added here once the API is stable. For now you can use the
[Event Capture](https://github.com/meenzen/Streamlabs.SocketClient/tree/main/src/Streamlabs.EventCapture) project
as a reference.

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
