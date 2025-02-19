using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;

namespace BestPracticesLogging.Benchmark;

public class Config : ManualConfig
{
    public Config()
    {
        AddColumn(StatisticColumn.Min);
        AddColumn(StatisticColumn.Max);
        AddColumn(StatisticColumn.P95); // 95th Percentile
        AddColumn(StatisticColumn.P50); // Median
        AddColumn(StatisticColumn.StdDev);
    }
}