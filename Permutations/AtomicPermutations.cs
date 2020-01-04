using System.Collections.Generic;

namespace Permutations
{
    public class AtomicPermutations<T> : IPermutations<T>
    { 
        private readonly GeneratingElements<T> generatingElements;

        public AtomicPermutations(GeneratingElements<T> generatingElements)
        {
            this.generatingElements = generatingElements;
        }
        
        public List<List<T>> Generate()
        {
            return new List<List<T>>
            {
                new List<T>
                {
                    generatingElements.First()
                }
            };
        }
    }
}