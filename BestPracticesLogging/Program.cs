using System.Diagnostics;
using System.Text.Json;
using BestPracticesLogging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

SetupSerilog(builder);
builder.Logging.ClearProviders();
builder.Services.AddSerilog();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// traditional logging
app.MapGet("/v1/log/{count}", (long count, ILogger<Program> logger) =>
{
    var timestamp = Stopwatch.GetTimestamp();
    Parallel.For(0, count, new ParallelOptions
    {
        MaxDegreeOfParallelism = Environment.ProcessorCount * 3
    }, i =>
    {
        logger.LogInformation("This is test log for Object: {Object}", JsonSerializer.Serialize(new LargeClass()));
    });
    
    return $"This is test log {count} at {Stopwatch.GetElapsedTime(timestamp)}";
});

// struct logging
app.MapGet("/v2/log/{count}", (long count, ILogger<Program> logger) =>
{
    var timestamp = Stopwatch.GetTimestamp();
    Parallel.For(0, count, new ParallelOptions
    {
        MaxDegreeOfParallelism = Environment.ProcessorCount * 3
    }, i =>
    {
        logger.LogInformation("This is test log for Object: {@LargeObject}", new LargeClass());
    });
    
    return $"This is test log {count} at {Stopwatch.GetElapsedTime(timestamp)}";
});

app.Run();

void SetupSerilog(WebApplicationBuilder webApplicationBuilder)
{
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(webApplicationBuilder.Configuration.GetSection("Logging"))
        .Enrich.FromLogContext()
        .Enrich.WithEnvironmentName()
        .Enrich.WithProperty("ApplicationName", webApplicationBuilder.Environment.ApplicationName)
        .WriteTo.Console(LogEventLevel.Information)
        .WriteTo.File(new ExceptionAsObjectJsonFormatter(renderMessage: true, inlineFields: true),"./logs/Logs-BestPracticesLogging.log", LogEventLevel.Information)
        .CreateLogger();
}