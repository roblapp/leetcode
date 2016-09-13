public class Solution {
    public bool IsPalindrome(int x) {
        var res = 0;
        var y = x;
        while (y > 0)
        {
            res = 10 * res + y % 10;
            y /= 10;
        }
        return x == res;
    }
}
