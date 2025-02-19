namespace BestPracticesLogging.Benchmark;

public class NullLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName) => new NullLogger();
    public void Dispose() { }
    class NullLogger : ILogger, IDisposable
    {
        private int _dummy;
        public IDisposable BeginScope<TState>(TState state) => new NullLogger();
        public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Information;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) => _dummy++;
        public void Dispose() { }
    }
}