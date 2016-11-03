public class Solution
{
    public string FrequencySort(string s)
    {
        var array = s.ToCharArray();
        var freq = new Dictionary<char, int>();

        foreach (var c in array)
        {
            if (freq.ContainsKey(c))
            {
                freq[c]++;
            }
            else
            {
                freq.Add(c, 1);
            }
        }

        Array.Sort(array, (a, b) =>
        {
            var x = freq[a];
            var y = freq[b];

            if (x > y)
            {
                return -1;
            }
            if (x < y)
            {
                return 1;
            }
            return a - b;
        });

        return new string(array);
    }
}
