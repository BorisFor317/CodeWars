using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TwiceLinear
{
    public class DoubleLinearTree
    {
        public uint Depth => (uint) levels.Count - 1;
        
        private List<TreeLevel> levels = new List<TreeLevel>();

        public DoubleLinearTree()
        {
            levels.Add(TreeLevel.ZeroLevel);
        }

        public DoubleLinearTree(uint depth)
        {
            levels.Add(TreeLevel.ZeroLevel);
            EnsureDepth(depth);
        }

        public IEnumerable<int> GetValues(uint startLevel, uint endLevel)
        {
            if (endLevel < startLevel)
                throw new ArgumentException("End level must be bigger or equal than start level");
            
            EnsureDepth(endLevel);
            for (var i = (int) startLevel; i <= endLevel; ++i)
            {
                var level = levels[i];
                for (var j = 0; j < level.Length; ++j)
                {
                    yield return level[j];
                }
            }
        }

        public void EnsureDepth(uint requestedDepth)
        {
            while (requestedDepth >= this.Depth)
            {
                var maxLevel = GetMaxLevel();
                var newLevel = TreeLevel.FromPrevious(maxLevel);
                levels.Add(newLevel);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TreeLevel GetMaxLevel() => levels[levels.Count - 1];
    }
}