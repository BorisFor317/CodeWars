using System.Collections.Generic;

namespace Permutations
{
    public interface IPermutations<T>
    {
        List<List<T>> Generate();
    }
}