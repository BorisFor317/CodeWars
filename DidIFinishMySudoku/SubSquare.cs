using System.Collections;
using System.Collections.Generic;

namespace DidIFinishMySudoku
{
    public class SubSquare : IEnumerable<int>
    {
        private readonly int[][] matrix;
        private readonly int rowBeginIndex;
        private readonly int columnBeginIndex;
        private readonly int rowEndIndex;
        private readonly int columnEndIndex;

        public SubSquare(int[][] matrix, int rowBeginIndex, int columnBeginIndex, int rowEndIndex, int columnEndIndex)
        {
            this.matrix = matrix;
            this.rowBeginIndex = rowBeginIndex;
            this.columnBeginIndex = columnBeginIndex;
            this.rowEndIndex = rowEndIndex;
            this.columnEndIndex = columnEndIndex;
        }

        public static IEnumerable<SubSquare> AllPossibleFromMatrix3X3(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length - 3; i += 3)
                for (int j = 0; j < matrix[0].Length - 3; j += 3)
                    yield return new SubSquare(matrix, i, j, i + 3, j + 3);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = rowBeginIndex; i < rowEndIndex; ++i)
            for (int j = columnBeginIndex; j < columnEndIndex; ++j)
                yield return matrix[i][j];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}