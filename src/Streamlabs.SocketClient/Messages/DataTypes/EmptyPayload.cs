using Streamlabs.SocketClient.Messages.Abstractions;
using System.Diagnostics.CodeAnalysis;

namespace Streamlabs.SocketClient.Messages.DataTypes;

[SuppressMessage("Minor Code Smell", "S2094:Classes should not be empty")]
public sealed record EmptyPayload : IPayload;
