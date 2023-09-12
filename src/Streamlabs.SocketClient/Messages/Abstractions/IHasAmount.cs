namespace Streamlabs.SocketClient.Messages.Abstractions;

public interface IHasAmount<TAmount>
    where TAmount : struct
{
    TAmount Amount { get; init; }
}
