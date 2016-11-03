public class Solution
{
    public void SolveSudoku(char[,] board)
    {
        SolveSudokuHelper(board, 0, 0);
    }

    private bool SolveSudokuHelper(char[,] board, int row, int col)
    {
        //If we've filled out rows 0 - 8 we're done
        if (row == 9) return true;

        var next = NextPosition(row, col);
        
        if (char.IsDigit(board[row, col]))
            return SolveSudokuHelper(board, next[0], next[1]);

        for (var c = '1'; c <= '9'; c++)
        {
            //Make move
            if (IsValidMove(board, c, row, col))
            {
                board[row, col] = c;
                if (SolveSudokuHelper(board, next[0], next[1]))
                {
                    return true;
                }
            }
        }

        board[row, col] = '.';

        return false;
    }

    private bool IsValidMove(char[,] board, char attempt, int row, int col)
    {
        //Check the row...
        var set = new HashSet<char>();

        for (var i = 0; i < 9; i++)
        {
            set.Add(board[row, i]);
        }

        if (set.Contains(attempt))
        {
            return false;
        }

        set.Clear();

        for (var i = 0; i < 9; i++)
        {
            set.Add(board[i, col]);
        }

        if (set.Contains(attempt))
        {
            return false;
        }

        var rowStart = row/3*3;
        var colStart = col/3*3;

        set.Clear();

        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                set.Add(board[rowStart + i, colStart + j]);
            }
        }
        if (set.Contains(attempt))
        {
            return false;
        }
        return true;
    }

    private int[] NextPosition(int row, int col)
    {
        if (col == 8)
        {
            return new[] {row + 1, 0};
        }
        return new[] { row, col + 1 };
    }
}
    