public class Solution {
    public bool IsValid(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return true;

        var st = new Stack<char>();
        var map = new Dictionary<char, char>
        {
            {'(', ')'}, {'{', '}'}, {'[', ']'}
        };

        foreach (var t in s)
        {
            if (IsOpening(t)) st.Push(map[t]);
            else if (st.Count == 0 || st.Pop() != t) return false;
        }

        return st.Count == 0;
    }

    private static bool IsOpening(char c)
    {
        return c == '(' || c == '{' || c == '[';
    }
}
