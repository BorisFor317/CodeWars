using BenchmarkDotNet.Running;

namespace Benchmarks
{
    class BenchmarkRun
    {
        static void Main(string[] args)
        { 
//            BenchmarkRunner.Run<DoubleLinearBenchmarks.TreeBenchmark>();
            BenchmarkRunner.Run<DoubleLinearBenchmarks.SequenceBenchmark>();
        }
    }
}