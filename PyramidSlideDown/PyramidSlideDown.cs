using System.Linq;
using static System.Math;

namespace PyramidSlideDown
{
    public class PyramidSlideDown
    {
        public static int LongestSlideDown(int[][] pyramid)
        {
            return pyramid
                .Reverse()
                .Aggregate(
                    (prev, cur) => cur
                        .Select((x, i) => x + Max(prev[i], prev[i + 1]))
                        .ToArray()
                )
                .First();
        }
    }
}