public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (string.IsNullOrWhiteSpace(s)) return 0;

        var map = new int[256];
        var n = s.Length;
        var soln = 0;

        for (int j = 0, i = 0; j < n; j++)
        {
            if (map[s[j]] > 0) //If the char is already in the map
            {
                i = Math.Max(i, map[s[j]]); //Keeps i moving forward (this skips i past the index where the existing duplicate character is
            }
            map[s[j]] = j + 1; //Set it to the next index (we need to tell the i in interval[i,j] where to jump to)
            soln = Math.Max(soln, j - i + 1);
        }
        return soln;
    }
}
