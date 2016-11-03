public class Solution
{
    public string AddStrings(string num1, string num2)
    {
        var len = Math.Max(num1.Length, num2.Length);
        var index1 = num1.Length - 1;
        var index2 = num2.Length - 1;
        var remainder = 0;
        var result = new StringBuilder();

        for (var i = 0; i <= len; i++)
        {
            var digit1 = index1 >= 0 ? num1[index1--] - '0' : 0;
            var digit2 = index2 >= 0 ? num2[index2--] - '0' : 0;
            var sum = digit1 + digit2 + remainder;
            result.Insert(0, sum%10);
            remainder = sum / 10;
        }

        var j = 0;
        while (j < result.Length - 1 && result[j] == '0')
        {
            j++;
        }

        return result.ToString().Substring(j);
    }
}
