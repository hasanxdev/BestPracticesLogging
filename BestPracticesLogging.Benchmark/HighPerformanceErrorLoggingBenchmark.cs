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
public class HighPerformanceErrorLoggingBenchmark
{
    private readonly ILogger<HighPerformanceErrorLoggingBenchmark> _logger;

    public HighPerformanceErrorLoggingBenchmark()
    {
        using var loggerFactory = LoggerFactory.Create(builder => builder
            .AddProvider(new NullLoggerProvider()));
        _logger = loggerFactory.CreateLogger<HighPerformanceErrorLoggingBenchmark>();
    }

    [Benchmark]
    public void TraditionalLogging()
    {
        try
        {
            throw new Exception("Test Ex");
        }
        catch (Exception e)
        {
            _logger.LogError("Test Ex: {@ex}", e);
        }
    }

    [Benchmark]
    public void OptimizedLogging()
    {
        try
        {
            throw new Exception("Test Ex");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Test Ex");
        }
    }
}