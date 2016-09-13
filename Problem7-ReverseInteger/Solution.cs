public class Solution {
    public int Reverse(int x) {
        try
        {
            checked
            {
                var res = 0;
                while (x != 0)
                {
                    res = 10 * res + x % 10;
                    x /= 10;
                }
                return res;
            }
        }
        catch (OverflowException)
        {
            return 0;
        }
    }
}
