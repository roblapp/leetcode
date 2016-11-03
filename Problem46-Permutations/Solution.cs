public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var resultList = new List<IList<int>>();
        var lengthOfItems = nums.Length;

        Permute(0, lengthOfItems, new int[lengthOfItems], nums, resultList);

        return resultList;
    }

    private void Permute(int k, int n, int[] a, IList<int> itemsToPermute, IList<IList<int>> soln)
    {
        //a contains the indices used so far
        if (k == n)
        {
            var tempResult = new List<int>();
            for (var i = 0; i < n; i++)
            {
                var index = a[i];
                tempResult.Add(itemsToPermute[index]);
            }
            soln.Add(tempResult);
            return;
        }

        var candidates = ConstructCandidates(k, n, a);

        foreach (var candidate in candidates)
        {
            a[k] = candidate;
            Permute(k + 1, n, a, itemsToPermute, soln);
        }
    }

    private IList<int> ConstructCandidates(int k, int n, int[] a)
    {
        // a contains the indices used so far
        var set = new HashSet<int>();
        var resultList = new List<int>();

        //Add each item being used so far
        for (var i = 0; i < k; i++)
        {
            set.Add(a[i]);
        }

        for (var i = 0; i < n; i++)
        {
            //If this value is not being used already
            if (!set.Contains(i))
            {
                resultList.Add(i);
            }
        }
        return resultList;
    }
}
