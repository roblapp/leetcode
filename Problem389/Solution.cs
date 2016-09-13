public class Solution {
    public char FindTheDifference(string s, string t) {
        var dic = new int[26];
        foreach (char t1 in s)
            dic[t1 - 'a']++;
        foreach (char t1 in t)
            dic[t1 - 'a']--;
        var index = Array.FindIndex(dic, x => x == -1);
        return (char) ('a' + index);
    }
}
