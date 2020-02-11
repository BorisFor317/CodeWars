using System.Collections.Generic;
using System.Linq;

namespace DidIFinishMySudoku
{
    public class Sudoku
    {
        private readonly int[][] board;
        private readonly IRule rule;

        public Sudoku(int[][] board, IRule rule)
        {
            this.board = board;
            this.rule = rule;
        }

        public bool IsSolved() => GetAllEnumerations().All(boardEnumeration => rule.IsValidFor(boardEnumeration));

        private IEnumerable<IEnumerable<int>> GetAllEnumerations()
        {
            foreach (var row in Row.AllPossibleFromMatrix(board)) 
                yield return row;

            foreach (var column in Column.AllPossibleFromMatrix(board)) 
                yield return column;

            foreach (var subSquare in SubSquare.AllPossibleFromMatrix3X3(board))
                yield return subSquare;
        }
    }
}