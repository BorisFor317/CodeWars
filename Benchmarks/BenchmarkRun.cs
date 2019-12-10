using System;
using BenchmarkDotNet.Running;
using TwiceLinear;

namespace Benchmarks
{
    class BenchmarkRun
    {
        static void Main(string[] args)
        { 
//            BenchmarkRunner.Run<DoubleLinearBenchmarks.TreeBenchmark>();
//            BenchmarkRunner.Run<DoubleLinearBenchmarks.SequenceBenchmark>();
            var sequence = new DoubleLinearSequence();
//            for (var i = 0; i < 1000; ++i)
//            {
//                var value = sequence.GetValue(i);
//                Console.WriteLine(value);
//            }
            Console.WriteLine(sequence.GetValue(2000));
        }
    }
}