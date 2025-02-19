using BenchmarkDotNet.Running;
using BestPracticesLogging.Benchmark;

var summary = BenchmarkRunner.Run<HighPerformanceErrorLoggingBenchmark>();