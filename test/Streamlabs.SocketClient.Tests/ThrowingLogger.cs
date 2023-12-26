using Microsoft.Extensions.Logging;

namespace Streamlabs.SocketClient.Tests;

/// <summary>
/// This logger is used to throw exceptions when logging is attempted with specific levels.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ThrowingLogger<T>(LogLevel throwLevel) : ILogger<T>
{
    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter
    )
    {
        if (IsEnabled(logLevel))
        {
            throw new Exception($"[{logLevel}] {formatter(state, exception)}");
        }
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel >= throwLevel;
    }

    public IDisposable? BeginScope<TState>(TState state)
        where TState : notnull
    {
        throw new NotImplementedException();
    }
}
