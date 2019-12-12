using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using TwiceLinear;

namespace Benchmarks
{
    public class DoubleLinearBenchmarks
    {
        [SimpleJob(RuntimeMoniker.NetCoreApp22)]
        public class SequenceBenchmark
        {
            [Params(100, 1000, 2000)]
            public int N;

            [Benchmark]
            public long ComputeEasyWay() => new DoubleLinearSequence().GetValue(N);
        }
    }
}