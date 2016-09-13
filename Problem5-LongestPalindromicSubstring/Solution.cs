public class Solution {
    public string LongestPalindrome(string s)
    {
        var index = 0;
        var maxlen = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var len1 = ExpandAroundCenter(s, i, i);
            var len2 = ExpandAroundCenter(s, i, i + 1);
            var len = Math.Max(len1, len2);
            if (len > maxlen)
            {
                index = i - (len - 1)/2;
                maxlen = len;
            }
        }
        return s.Substring(index, maxlen);
    }

    private int ExpandAroundCenter(string s, int left, int right)
    {
        var L = left;
        var R = right;

        while (L >= 0 && R < s.Length && s[L] == s[R])
        {
            L--;
            R++;
        }
        return R - L - 1;
    }
}
