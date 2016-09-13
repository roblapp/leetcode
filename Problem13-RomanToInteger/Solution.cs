public class Solution {
    public int RomanToInt(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return 0;

        var result = 0;
        var valueMap = new Dictionary<string, int>
        {
            {"I", 1}, {"IV", 4}, {"V", 5}, {"IX", 9},
            {"X", 10}, {"XL", 40}, {"L", 50}, {"XC", 90},
            {"C", 100}, {"CD", 400}, {"D", 500}, {"CM", 900}, {"M", 1000}
        };

        while (!string.IsNullOrEmpty(s))
        {
            if (FirstNCharsMatch(s, 3))
            {
                result += 3 * valueMap[s.Substring(0, 1)];
                s = s.Substring(3);
            }
            else if (FirstNCharsMatch(s, 2))
            {
                result += 2 * valueMap[s.Substring(0, 1)];
                s = s.Substring(2);
            }
            else if (IsTwoDigitRomanNumeral(s, valueMap))
            {
                result += valueMap[s.Substring(0, 2)];
                s = s.Substring(2);
            }
            else
            {
                result += valueMap[s.Substring(0, 1)];
                s = s.Substring(1);
            }
        }

        return result;
    }

    private bool IsTwoDigitRomanNumeral(string s, Dictionary<string, int> valueMap)
    {
        if (string.IsNullOrWhiteSpace(s)) return false;
        var x = s.Length;
        if (x < 2) return false;
        return valueMap[s.Substring(0, 1)] < valueMap[s.Substring(1, 1)];
    }

    private bool FirstNCharsMatch(string s, int n)
    {
        if (string.IsNullOrWhiteSpace(s)) return false;
        var x = s.Length;
        if (x < n) return false;
        var stop = Math.Min(x, n) - 1;
        for (var i = 0; i < stop; i++)
        {
            if (s[i] != s[i + 1]) return false;
        }
        return true;
    }
}
