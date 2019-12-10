using System;
using System.Runtime.CompilerServices;

namespace TwiceLinear
{
    public class TreeLevel
    {
        public uint Level { get; }
        public int Length => values.Length;
        
        private long[] values;
        
        private TreeLevel(uint level)
        {            
            this.Level = level;
            var levelLength = (int) Math.Pow(2, this.Level);
            this.values = new long[levelLength];
        }

        public static TreeLevel ZeroLevel
        {
            get
            {
                var zeroLevel = new TreeLevel(0);
                zeroLevel[0] = 1;

                return zeroLevel; 
            }
        }

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

        public long this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => values[index];
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private set => values[index] = value;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long Y(int x) => 2 * x + 1;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long Z(int x) => 3 * x + 1;
    }
}