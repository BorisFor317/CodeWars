using System.Collections;
using System.Collections.Generic;

namespace DidIFinishMySudoku
{
    public class Column : IEnumerable<int>
    {
        private readonly int[][] matrix;
        private readonly int index;
        
        public Column(int[][] matrix, int index)
        {
            this.matrix = matrix;
            this.index = index;
        }

        public static IEnumerable<Column> AllPossibleFromMatrix(int[][] matrix)
        {
            for (int j = 0; j < matrix[0].Length; ++j)
                yield return new Column(matrix, j);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < matrix.Length; ++i)
            {
                yield return matrix[i][index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}