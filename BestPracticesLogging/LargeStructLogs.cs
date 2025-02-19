namespace BestPracticesLogging;

public static partial class LargeStructLogs
{
    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Information,
        Message = "This is test log for Object: {index}, {now}, {@largeStruct}")]
    public static partial void TestLogForLargeObject(this ILogger logger, long index, DateTime now, LargeStruct largeStruct);
}