using System.Collections;
using System.Collections.Generic;

namespace DidIFinishMySudoku
{
    public class Row : IEnumerable<int>
    {
        private readonly int[][] matrix;
        private readonly int index;

        public Row(int[][] matrix, int index)
        {
            this.matrix = matrix;
            this.index = index;
        }

        public static IEnumerable<Row> AllPossibleFromMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; ++i)
                yield return new Row(matrix, i);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return (matrix[index] as IEnumerable<int>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}