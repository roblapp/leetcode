public class Solution {
	//Uses divide and conquer so we cut down on search space
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0) return string.Empty;
        return LongestCommonPrefix(strs, 0, strs.Length - 1);
    }

    private string LongestCommonPrefix(string[] strs, int l, int r)
    {
        if (l == r) return strs[l];

        var mid = (l + r) >> 1;
        var longestLeft = LongestCommonPrefix(strs, l, mid);
        var longestRight = LongestCommonPrefix(strs, mid + 1, r);
        return LongestCommonPrefixHelper(longestLeft, longestRight);
    }

    private string LongestCommonPrefixHelper(string sa, string sb)
    {
        var len = Math.Min(sa.Length, sb.Length);
        for (var i = 0; i < len; i++)
        {
            if (sa[i] != sb[i])
                return sa.Substring(0, i);
        }
        return sa.Substring(0, len);
    }
}
