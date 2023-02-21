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
}

public class ConsoleLogger : ILogger
{
    // if your Logger uses unmanaged resources, you can
    // return the class that implements IDisposable here
    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }
}
