public class Solution {
    public IList<int> LexicalOrder(int n)
    {
        var result = new List<int>();
        for (var i = 1; i <= 9; i++)
        {
            LexicalOrderHelper(i, n, result);
        }
        return result;
    }

    private void LexicalOrderHelper(int current, int n, IList<int> list)
    {
        if (current > n) return;
        list.Add(current);
        for (var i = 0; i < 10; i++)
        {
            if (10*current > n) return;
            LexicalOrderHelper(10*current + i, n, list);
        }
    }
}

