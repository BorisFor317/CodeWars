namespace DidIFinishMySudoku
{
    public class SudokuRunner
    {
        private static IRule rule = new AllRule(
            new NoZerosRule(), new AllUniqueRule()
        );
        
        public static string DoneOrNot(int[][] board)
        {
            return new Sudoku(board, rule).IsSolved() ?
                "Finished!" :
                "Try again!";
        }
    }
}