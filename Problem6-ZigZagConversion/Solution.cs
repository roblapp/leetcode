public class Solution {
    public string Convert(string s, int numRows) {
        if (string.IsNullOrWhiteSpace(s) || s.Length < numRows) return s;

        var i = 0;
        var n = s.Length;
        var map = new Dictionary<int, StringBuilder>();

        for (var j = 1; j <= numRows; j++)
        {
            map[j] = new StringBuilder();
        }

        while (i < n)
        {
            for (var j = 1; j <= numRows && i < n; j++)
            {
                map[j].Append(s[i]);
                i++;
            }

            for (var j = numRows - 1; j >= 2 && i < n; j--)
            {
                map[j].Append(s[i]);
                i++;
            }
        }

        var result = new StringBuilder();
        for (var j = 1; j <= numRows; j++)
        {
            result.Append(map[j]);
        }
        return result.ToString();
    }
}
