using Streamlabs.SocketClient.Events;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages;

/// <summary>
/// The message array for <see cref="MuteVolumeEvent"/> seems to be always empty,
/// so this message type is just a placeholder.
/// </summary>
public sealed record MuteVolumeMessage : IStreamlabsMessage
{
    // Empty
}
