public class Solution
{
    public IList<int> SpiralOrder(int[,] matrix)
    {
        var rowMin = 0;
        var rowMax = matrix.GetLength(0) - 1;
        var colMin = 0;
        var colMax = matrix.GetLength(1) - 1;
        var nSeen = 0;
        var resultList = new List<int>();

        if (matrix.Length == 0) return resultList;

        while (true)
        {
            var currentRow = rowMin;
            var currentCol = colMax;

            //COL LEFT TO RIGHT
            for (var i = colMin; i <= colMax; i++)
            {
                //Console.WriteLine($"{currentRow}, {i}");
                resultList.Add(matrix[currentRow, i]);
                nSeen++;
                if (nSeen == matrix.Length) return resultList;
            }

            rowMin++;

            //ROW TOP TO BOTTOM
            for (var i = rowMin; i <= rowMax; i++)
            {
                //Console.WriteLine($"{i}, {currentCol}");
                resultList.Add(matrix[i, currentCol]);
                nSeen++;
                if (nSeen == matrix.Length) return resultList;
            }

            colMax--;
            currentRow = rowMax;

            //COL RIGHT TO LEFT
            for (var i = colMax; i >= colMin; i--)
            {
                //Console.WriteLine($"{currentRow}, {i}");
                resultList.Add(matrix[currentRow, i]);
                nSeen++;
                if (nSeen == matrix.Length) return resultList;
            }

            rowMax--;
            currentCol = colMin;

            //ROW BOTTOM TO TOP
            for (var i = rowMax; i >= rowMin; i--)
            {
                //Console.WriteLine($"{i}, {currentCol}");
                resultList.Add(matrix[i, currentCol]);
                nSeen++;
                if (nSeen == matrix.Length) return resultList;
            }

            colMin++;
        }
    }
}
