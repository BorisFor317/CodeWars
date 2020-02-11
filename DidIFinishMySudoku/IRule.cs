using System.Collections.Generic;
using System.Linq;

namespace DidIFinishMySudoku
{
    public interface IRule
    {
        bool IsValidFor(IEnumerable<int> sequence);
    }

    public class AllRule : IRule
    {
        private readonly IRule[] rules;

        public AllRule(params IRule[] rules)
        {
            this.rules = rules;
        }

        public bool IsValidFor(IEnumerable<int> sequence)
        {
            return rules.All(rule => rule.IsValidFor(sequence));
        }
    }

    public class NoZerosRule : IRule
    {
        public bool IsValidFor(IEnumerable<int> sequence) => sequence.All(e => e != 0);
    }

    public class AllUniqueRule : IRule
    {
        public bool IsValidFor(IEnumerable<int> sequence)
        {
            var counted = new int[9];
            foreach (var element in sequence)
                counted[element - 1] += 1;
            return counted.All(c => c == 1);
        }
    }
}