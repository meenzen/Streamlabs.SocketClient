using System.Diagnostics.CodeAnalysis;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages.DataTypes;

[SuppressMessage("Minor Code Smell", "S2094:Classes should not be empty")]
public sealed record EmptyPayload : IPayload;
