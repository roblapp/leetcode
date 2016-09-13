
public class Solution {
    public int FirstUniqChar(string s) {
        var a = new int[26];

        foreach (var c in s)
            a[c - 'a']++;

        for (var i = 0; i < s.Length; i++)
            if (a[s[i] - 'a'] == 1)
                return i;

        return -1;
    }
}
