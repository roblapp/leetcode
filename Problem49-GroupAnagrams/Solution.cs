public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var map = new Dictionary<string, IList<string>>();
        foreach (var str in strs)
        {
            var key = string.Concat(str.OrderBy(c => c));
            if (map.ContainsKey(key))
            {
                map[key].Add(str);
            }
            else
            {
                map[key] = new List<string>
                {
                    str
                };
            }
        }
        var resultList = new List<IList<string>>();
        foreach (var key in map.Keys)
        {
            resultList.Add(map[key]);
        }

        return resultList;
    }
}
