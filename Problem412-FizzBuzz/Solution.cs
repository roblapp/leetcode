public class Solution
{
    public IList<string> FizzBuzz(int n)
    {
        var resultList = new List<string>();

        for (var i = 1; i <= n; i++)
        {
            if (i % 15 == 0)
                resultList.Add("FizzBuzz");
            else if (i % 5 == 0)
                resultList.Add("Buzz");
            else if (i % 3 == 0)
                resultList.Add("Fizz");
            else
                resultList.Add($"{i}");
        }

        return resultList;
    }
}
