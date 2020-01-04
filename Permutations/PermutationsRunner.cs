using System.Collections.Generic;
using System.Linq;

namespace Permutations
{
    public class PermutationsRunner
    {
        public static List<string> SinglePermutations(string s)
        {
            var charArray = s.ToCharArray();

            var permutations = new AtomicIfOneElementSelector<char>().Select(
                new GeneratingElements<char>(charArray)
            ).Generate();

            return permutations.Select(p => new string(p.ToArray())).ToList();
        }
    }
}