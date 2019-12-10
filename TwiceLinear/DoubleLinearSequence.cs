using System;
using System.Collections.Generic;
using System.Linq;

namespace TwiceLinear
{
    public class DoubleLinearSequence
    {
        // Was computed as m / n, where
        // n -- level, at was computed only 'Z'
        // m -- level, which only 'Y' would beat only 'Z' at level n
        private const double NeededLevelScale = 2;
        
        private DoubleLinearTree tree = new DoubleLinearTree();
        private SortedSet<int> sequence = new SortedSet<int>();

        private uint lastLevelAdded;
        
        public int GetValue(int index)
        {
            var neededLevel = GetNeededLevel(index);
            if (neededLevel > lastLevelAdded)
            {
                AddLevelToSequence(neededLevel);
            }

            return sequence.ElementAt(index);
        }

        private void AddLevelToSequence(uint level)
        {
            foreach (var value in tree.GetValues(lastLevelAdded, level))
            {
                sequence.Add(value);
            }
            
            lastLevelAdded = level;
        }

        private static uint GetNeededLevel(int index)
        {
            var minLevel = IndexToMinLevel(index);
            var neededLevelApproximation = minLevel * NeededLevelScale;
            return (uint) Math.Ceiling(neededLevelApproximation);
        }

        private static uint IndexToMinLevel(int index)
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