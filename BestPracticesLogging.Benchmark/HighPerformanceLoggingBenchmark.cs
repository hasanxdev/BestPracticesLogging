using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Logging;

namespace BestPracticesLogging.Benchmark;

[MemoryDiagnoser(true)]
[SimpleJob(RuntimeMoniker.Net90)]
[Config(typeof(Config))]
public class HighPerformanceLoggingBenchmark
{
    private readonly ILogger<HighPerformanceLoggingBenchmark> _logger;

    public HighPerformanceLoggingBenchmark()
    {
        using var loggerFactory = LoggerFactory.Create(builder => builder
            .AddProvider(new NullLoggerProvider()));
        _logger = loggerFactory.CreateLogger<HighPerformanceLoggingBenchmark>();
    }

    [Benchmark]
    public void LogWithBoxing()
    {
        _logger.LogInformation("Processing user {index1} {index2} {index3} {index4} at {time}", 1,2,3,4, DateTime.Now);
    }

    [Benchmark]
    public void LogWithoutBoxing()
    {
        _logger.ProcessingUser(1,2,3,4, DateTime.Now);
    }
}

public static partial class MyOptimizedLogger
{
    [LoggerMessage(EventId = 1001, Level = LogLevel.Information, Message = "Processing user {index1} {index2} {index3} {index4} at {time}")]
    public static partial void ProcessingUser(this ILogger logger, int index1, int index2, int index3, int index4, DateTime time);
}
