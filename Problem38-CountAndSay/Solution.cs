public class Solution
{
    private class Entry
    {
        public char Digit { get; set; }

        public int Frequency { get; set; }
    }

    public string CountAndSay(int n)
    {
        var num = "1";

        if (n <= 1) return num;

        for (var i = 1; i < n; i++)
        {
            var dataList = CountInOrder(num);
            var sb = new StringBuilder();
            foreach (var element in dataList)
            {
                sb.Append(element.Frequency);
                sb.Append(element.Digit);
            }
            num = sb.ToString();
        }

        return num;
    }

    private static IList<Entry> CountInOrder(string number)
    {
        var resultList = new List<Entry>();
        
        if (string.IsNullOrEmpty(number)) return resultList;

        var digit = number[0];
        var count = 1;

        for (var i = 1; i < number.Length; i++)
        {
            if (number[i] == digit)
            {
                count++;
            }
            else
            {
                resultList.Add(
                    new Entry
                    {
                        Digit = digit,
                        Frequency = count
                    });
                digit = number[i];
                count = 1;
            }
        }

        resultList.Add(
            new Entry
            {
                Digit = digit,
                Frequency = count
            });

        return resultList;
    }
}
