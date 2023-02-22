using Microsoft.Extensions.Logging; // ILoggerProvider, ILogger, LogLevel
using static System.Console;

namespace Packt.Shared;

public class ConsoleLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        // we could have different Logger implementations for
        // diffenrent categoryName values but we only have one
        return new ConsoleLogger();
    }
    // if your logger uses unmanaged resources,
    // then you can release them here
    public void Dispose() { }
}

public class ConsoleLogger : ILogger
{
    // if your Logger uses unmanaged resources, you can
    // return the class that implements IDisposable here
    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }
    public bool IsEnabled(LogLevel logLevel)
    {
        // to avoid overlogging, you ca nfilter on the log level
        switch (logLevel)
        {
            case LogLevel.Trace:
            case LogLevel.Information:
            case LogLevel.None:
                return false;
            case LogLevel.Debug:
            case LogLevel.Warning:
            case LogLevel.Error:
            case LogLevel.Critical:
            default:
                return true;
        };
    }
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception, string> formatter)
    {
        if(eventId.Id == 20100)
        {
            // Log the level and event identifier
            Write($"Level: {logLevel}, Event Id: {eventId}");
            // only output the state or exception if it exists
            if (state != null)
            {
                Write($", state: {state}");
            }
            if (exception != null)
            {
                Write($", Exception: {exception.Message}");
            }
            WriteLine();
        }
    }
}
