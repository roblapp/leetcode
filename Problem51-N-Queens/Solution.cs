public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        var result = new List<IList<string>>();
        if (n <= 0) return result;

        SolveNQueensHelper(result, new bool[n,n], 0, n);

        return result;
    }

    private void SolveNQueensHelper(IList<IList<string>> viewableBoard, bool[,] board, int row, int n)
    {
        if (row == n)
        {
            viewableBoard.Add(
                AppendBoardConfiguration(board)
            );

            return;
        }

        //Attempt each column
        for (var i = 0; i < n; i++)
        {
            if (IsOk(board, row, i))
            {
                //Make move
                board[row,i] = true;

                //Sovle remaining rows
                SolveNQueensHelper(viewableBoard, board, row + 1, n);

                //Unmake move
                board[row,i] = false;
            }
        }
    }

    private IList<string> AppendBoardConfiguration(bool[,] board)
    {
        var result = new List<string>();

        var nRows = board.GetLength(0);
        var nCols = board.GetLength(1);

        for (var i = 0; i < nRows; i++)
        {
            var sb = new StringBuilder();
            for (var j = 0; j < nCols; j++)
            {
                //If value is true then it's a queen otherwise it's empty
                sb.Append(board[i, j] ? 'Q' : '.');
            }
            result.Add(sb.ToString());
        }
        return result;
    }

    private bool IsOk(bool[,] board, int row, int col)
    {
        if (row == 0) return true;

        var nRows = board.GetLength(0);
        var nCols = board.GetLength(1);
       
        //No need to check the row because our algorithm places one queen per row
        //Check column (vertical traversal)
        for (var i = 0; i < nRows; i++)
        {
            //If there's a queen, we cannot move here
            if (board[i, col]) return false;
        }

        var tempRow = row;
        var tempCol = col;
        //Check diagonal \... go to the start of the diagonal
        while (tempRow > 0 && tempCol > 0)
        {
            tempRow--;
            tempCol--;
        }

        while (tempRow < nRows && tempCol < nCols)
        {
            //If there's a queen, we cannot move here
            if (board[tempRow, tempCol]) return false;
            tempRow++;
            tempCol++;
        }

        //Now check this diagonal /
        tempRow = row;
        tempCol = col;
        while (tempRow >= 0 && tempCol < nCols)
        {
            //If there's a queen, we cannot move here
            if (board[tempRow, tempCol]) return false;
            tempRow--;
            tempCol++;
        }

        return true;
    }
}
