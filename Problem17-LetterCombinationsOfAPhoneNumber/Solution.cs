public class Solution {
    public IList<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrWhiteSpace(digits))
        {
            return new List<string>();
        }
            
        var map = new Dictionary<int, string>
        {
            {1, ""},
            {2, "abc"}, {3, "def"}, {4, "ghi"},
            {5, "jkl"}, {6, "mno"}, {7, "pqrs"},
            {8, "tuv"}, {9, "wxyz"}, {0, ""}
        };
        var soln = new List<string>();
        LetterCombinationsHelper(digits, map, soln, string.Empty);
        return soln;
    }

    private void LetterCombinationsHelper(string digits, Dictionary<int, string> map, IList<string> soln, string temp)
    {
        if (string.IsNullOrWhiteSpace(digits))
        {
            soln.Add(temp);
            return;
        }
        var str = map[int.Parse(digits.Substring(0, 1))];
        var remainingStr = digits.Substring(1);

        foreach (var c in str)
        {
            LetterCombinationsHelper(remainingStr, map, soln, temp + c);
        }
    }
}
