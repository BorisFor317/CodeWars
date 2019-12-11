using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TwiceLinear
{
    public class TreeLevel : IEnumerable<long>
    {
        public uint Level { get; }
        public int Length => values.Length;
        
        public const int MaxPossibleLevel = 63;
        
        private long[] values;
        
        private TreeLevel(uint level)
        {
            if (level > MaxPossibleLevel)
                throw new OverflowException(
                    $"Requested level is bigger than max possible level, which is {MaxPossibleLevel}"
                    );
            
            this.Level = level;
            var levelLength = TwoInPower((int) level);
            this.values = new long[levelLength];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int TwoInPower(int power) => 1 << power;
        
        public static TreeLevel FromPrevious(TreeLevel previousLevel)
        {
            var treeLevel = new TreeLevel(previousLevel.Level + 1);
            for (int i = 0; i < treeLevel.Length; i += 2)
            {
                var previousTreeValue = previousLevel[i / 2];
                treeLevel[i] = Y(previousTreeValue);
                treeLevel[i + 1] = Z(previousTreeValue);
            }
            
            return treeLevel;
        }
        
        public static TreeLevel ZeroLevel
        {
            get
            {
                var zeroLevel = new TreeLevel(0) { [0] = 1 };
                return zeroLevel;
            }
        }

        public long this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => values[index];
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private set => values[index] = value;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long Y(long x) => 2 * x + 1;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long Z(long x) => 3 * x + 1;
        
        public IEnumerator<long> GetEnumerator()
        {
            return values.Cast<long>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}