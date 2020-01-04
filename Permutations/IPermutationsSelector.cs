namespace Permutations
{
    public interface IPermutationsSelector<T>
    {
        IPermutations<T> Select(GeneratingElements<T> generatingElements);
    }
}