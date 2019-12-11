using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TwiceLinear
{
    public class DoubleLinearTree
    {
        public uint Depth => (uint) levels.Count - 1;
        
        private List<TreeLevel> levels = new List<TreeLevel>(TreeLevel.MaxPossibleLevel);

        public DoubleLinearTree()
        {
            levels.Add(TreeLevel.ZeroLevel);
        }

        public DoubleLinearTree(uint depth)
        {
            levels.Add(TreeLevel.ZeroLevel);
            EnsureDepth(depth);
        }
        
        public TreeLevel GetLevel(int level)
        {
            EnsureDepth((uint) level);
            return levels[level];
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EnsureDepth(uint requestedDepth)
        {
            while (Depth < requestedDepth)
            {
                var lastLevel = GetLastLevel();
                var newLevel = TreeLevel.FromPrevious(lastLevel);
                levels.Add(newLevel);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TreeLevel GetLastLevel() => levels[levels.Count - 1];
    }
}