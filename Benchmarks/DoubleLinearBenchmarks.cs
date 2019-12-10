using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using TwiceLinear;

namespace Benchmarks
{
    public class DoubleLinearBenchmarks
    {
        [SimpleJob(RuntimeMoniker.NetCoreApp22)]
        public class TreeBenchmark
        {
            [Params(5, 10, 15)]
            public uint N;

            [Benchmark]
            public DoubleLinearTree ComputeDoubleLinearTree() => new DoubleLinearTree(N);
        }

        [SimpleJob(RuntimeMoniker.NetCoreApp22)]
        public class SequenceBenchmark
        {
            [Params(100, 1000)]
            public int N;
            
            [Benchmark]
            public int ComputeDoubleLinearTree() => new DoubleLinearSequence().GetValue(N);
        }
    }
}