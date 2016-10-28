public class Solution
{
    public bool IsValidSudoku(char[,] board)
    {
        var candidates = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        for (var i = 0; i < 9; i++)
        {
            var set = new HashSet<char>();

            for (var j = 0; j < 9; j++)
            {
                var c = board[i, j];
                if (c != '.')
                {
                    //If the number is already in use OR it is not a valid entry 1-9 (and also not a . which is used for empty cells)
                    if (set.Contains(c) || !candidates.Contains(c)) return false;
                    set.Add(c);
                }
            }
        }

        for (var i = 0; i < 9; i++)
        {
            var set = new HashSet<char>();

            for (var j = 0; j < 9; j++)
            {
                var c = board[j, i];
                if (c != '.')
                {
                    //If the number is already in use OR it is not a valid entry 1-9 (and also not a . which is used for empty cells)
                    if (set.Contains(c) || !candidates.Contains(c)) return false;
                    set.Add(c);
                }
            }
        }

        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                var row = 3 * i;
                var col = 3 * j;
                var set = new HashSet<char>();

                for (var k = 0; k < 3; k++)
                {
                    for (var m = 0; m < 3; m++)
                    {
                        var c = board[row + k, col + m];
                        if (c != '.')
                        {
                            //If the number is already in use OR it is not a valid entry 1-9 (and also not a . which is used for empty cells)
                            if (set.Contains(c) || !candidates.Contains(c)) return false;
                            set.Add(c);
                        }
                    }
                }
            }
        }
        return true;
    }
}
