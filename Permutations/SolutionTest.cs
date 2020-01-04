using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Permutations
{
    public class SolutionTest
    {
        [Test]
        public void Example1()
        {
            Assert.AreEqual(new List<string> { "a" }, PermutationsRunner.SinglePermutations("a").OrderBy(x => x).ToList());
        }

        [Test]
        public void Example2()
        {
            Assert.AreEqual(new List<string> { "ab", "ba" }, PermutationsRunner.SinglePermutations("ab").OrderBy(x => x).ToList());
        }

        [Test]
        public void Example3()
        {
            Assert.AreEqual(new List<string> { "aabb", "abab", "abba", "baab", "baba", "bbaa" }, PermutationsRunner.SinglePermutations("aabb").OrderBy(x => x).ToList());
        }
    }
}