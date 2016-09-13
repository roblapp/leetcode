public class Solution {
    public struct RomanNumeral
    {
        public int Value;
        public string Display;

        public RomanNumeral(int value, string display)
        {
            Value = value;
            Display = display;
        }
    }

    public string IntToRoman(int num)
    {
        if (num < 1 || num > 3999) throw new ArgumentException();
        var powerOfTen = 0;
        var result = string.Empty;
        var array = new[]
        {
            new RomanNumeral(1, "I"),
            new RomanNumeral(4, "IV"), new RomanNumeral(5, "V"), new RomanNumeral(9, "IX"), new RomanNumeral(10, "X"),
            new RomanNumeral(40, "XL"), new RomanNumeral(50, "L"), new RomanNumeral(90, "XC"), new RomanNumeral(100, "C"),
            new RomanNumeral(400, "CD"), new RomanNumeral(500, "D"), new RomanNumeral(900, "CM"), new RomanNumeral(1000, "M")
        };

        while (num > 0)
        {
            var value = num % 10 * (int)Math.Pow(10, powerOfTen);
            var temp = string.Empty;
            while (value > 0)
            {
                var res = GetHighestValueThatFits(array, value);
                value -= res.Value;
                temp += res.Display;
            }
            result = temp + result;
            num /= 10;
            powerOfTen++;
        }
        return result;
    }

    private RomanNumeral GetHighestValueThatFits(RomanNumeral[] array, int value)
    {
        var i = 1;
        var result = array[0];
        while (i < array.Length && array[i].Value <= value)
        {
            result = array[i];
            i++;
        }
        return result;
    }
}
