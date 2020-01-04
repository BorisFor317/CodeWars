using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Permutations;

namespace Benchmarks
{
    public class PermutationsBenchmark
    {
        private string input;
        
        [Params(6, 7, 8, 10)]
        public int N;
        
        [GlobalSetup]
        public void Setup()
        {
            input = RandomString(N);
        }

        [Benchmark]
        public List<string> MyVariant() => PermutationsRunner.SinglePermutations(input);

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(chars.Take(length).ToArray());
        }
    }
}