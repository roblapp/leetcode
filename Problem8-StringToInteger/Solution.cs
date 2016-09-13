public class Solution {
    public int MyAtoi(string str) {
        if (string.IsNullOrWhiteSpace(str))
        {
            return 0;
        }
        
        var s = str.TrimStart(' ', '\t', '\n');
        
        if (string.IsNullOrWhiteSpace(s))
        {
            return 0;
        }

        var i = 0;
        var isNeg = false;

        if (s[i] == '-')
        {
            isNeg = true;
            i++;
        }
        else if (s[i] == '+')
        {
            i++;
        }

        try
        {
            checked
            {
                var res = 0;
                while (i < s.Length && char.IsDigit(s[i]))
                {
                    res = 10 * res + (s[i] - '0');
                    i++;
                }
                if (isNeg)
                {
                    res *= -1;
                }

                return res;
            }
        }
        catch (OverflowException)
        {
            return isNeg ? int.MinValue : int.MaxValue;
        }
        catch (Exception)
        {
            return 0;
        }
    }
}
