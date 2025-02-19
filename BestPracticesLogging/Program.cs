using System.Diagnostics;
using System.Text.Json;
using BestPracticesLogging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog((hostingContext, loggerConfig) =>
{
    loggerConfig.Enrich.FromLogContext()
        .Enrich.WithEnvironmentName()
        .Enrich.WithProperty("ApplicationName", builder.Environment.ApplicationName)
        .WriteTo.Async(a => a
            .Console(new ExceptionAsObjectJsonFormatter(renderMessage: true, inlineFields: true),
                LogEventLevel.Information)
            .WriteTo.File(new ExceptionAsObjectJsonFormatter(renderMessage: true, inlineFields: true),
                "./logs/Logs-BestPracticesLogging.log", LogEventLevel.Information));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Logger.LogInformation("This is test log for Object: {index}, {now}, {@largeStruct}", 1, DateTime.Now, new LargeStruct());

app.MapGet("/v1/log/{count}", (long count, ILogger<Program> logger) =>
{
    var timestamp = Stopwatch.GetTimestamp();
    Parallel.For(0, count, new ParallelOptions
    {
        MaxDegreeOfParallelism = 20
    }, i =>
    {
        logger.LogInformation("This is test log for Object: {index}, {now}, {@largeStruct}", i, DateTime.Now, new LargeStruct());
    });
    
    return $"This is test log {count} at {Stopwatch.GetElapsedTime(timestamp)}";
});

app.Run();