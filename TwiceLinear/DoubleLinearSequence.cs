using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TwiceLinear
{
    public class DoubleLinearSequence
    {
        // Was computed as m / n, where
        // n -- level, at was computed only 'Z'
        // m -- level, which only 'Y' would beat only 'Z' at level n
        private const double NeededLevelScale = 1.585;
        
        private DoubleLinearTree tree = new DoubleLinearTree();
        private SortedSet<long> sequence = new SortedSet<long>();

        private uint lastLevelAdded;
        
        public long GetValue(int index)
        {
            var neededLevel = GetNeededLevel(index);
            if (neededLevel > lastLevelAdded)
            {
                AddLevelsToSequence(neededLevel);
            }

            return sequence.ElementAt(index);
        }

        private void AddLevelsToSequence(uint level)
        {
            for (var i = (int) lastLevelAdded; i < level; ++i)
            {
                sequence.UnionWith(tree.GetLevel(i));
            }
            
            lastLevelAdded = level;
        }

        private static uint GetNeededLevel(long index)
        {
            var minLevel = IndexToMinLevel(index);
            var neededLevelApproximation = minLevel * NeededLevelScale;
            return (uint) Math.Ceiling(neededLevelApproximation);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint IndexToMinLevel(long index)
        {
            var level = 0;
            var count = 0;
            while (count <= index)
            {
                count |= 1 << level;
                ++level;
            }

            return (uint) level;
        }
    }
}