namespace Permutations
{
    public class AtomicIfOneElementSelector<T> : IPermutationsSelector<T>
    {
        public IPermutations<T> Select(GeneratingElements<T> generatingElements)
        {
            if (generatingElements.Size == 1)
                return new AtomicPermutations<T>(generatingElements);
            
            return new CompositePermutations<T>(generatingElements, this);
        }
    }
}