using System.Collections.Generic;

namespace Permutations
{   
    public class CompositePermutations<T> : IPermutations<T>
    {
        private readonly GeneratingElements<T> generatingElements;
        private readonly IPermutationsSelector<T> permutationsSelector;
        
        public CompositePermutations(GeneratingElements<T> generatingElements, IPermutationsSelector<T> permutationsSelector)
        {
            this.generatingElements = generatingElements;
            this.permutationsSelector = permutationsSelector;
        }

        public List<List<T>> Generate()
        {
            var aggregator = new List<List<T>>();
            foreach (var distinctElement in generatingElements.DistinctElements)
            {
                var newGeneratingElements = generatingElements.WithoutOne(distinctElement);
                var permutations = permutationsSelector.Select(newGeneratingElements);
                var generated  = permutations.Generate();
                foreach (var permutation in generated)
                {
                    permutation.Add(distinctElement);
                }
                aggregator.AddRange(generated);
            }

            return aggregator;
        }
    }
}