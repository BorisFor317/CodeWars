using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TwiceLinear
{
    public class DoubleLinearSequence
    {
        private List<long> sequence = new List<long>();
        private SortedSet<long> computationQueue = new SortedSet<long>{ 1 };
        
        public long GetValue(int index)
        {
            while (sequence.Count <= index)
            {
                var min = computationQueue.Min;
                computationQueue.Remove(min);
                sequence.Add(min);
                computationQueue.Add(Y(min));
                computationQueue.Add(Z(min));
            }

            return sequence[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long Y(long x) => 2 * x + 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long Z(long x) => 3 * x + 1;
    }
}
