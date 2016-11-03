 public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var soln = new List<IList<int>>();

        CombinationSum(soln, candidates, target, 0, new List<int>());

        return soln;
    }

    public void CombinationSum(IList<IList<int>> soln, int[] candidates, int target, int index, IList<int> current)
    {
        if (index == candidates.Length)
        {
            if (target == 0)
            {
                soln.Add(current.ToList());
            }

            return;
        }

        var mult = 0;

        while (target - mult*candidates[index] >= 0)
        {
            AddNTimes(current, candidates[index], mult);
            CombinationSum(soln, candidates, target - mult*candidates[index], index + 1, current);
            RemoveLastNElements(current, mult);
            mult++;
        }
    }

    private static void AddNTimes(IList<int> list, int element, int n)
    {
        for (var i = 0; i < n; i++)
        {
            list.Add(element);
        }
    }

    private static void RemoveLastNElements(IList<int> list, int n)
    {
        for (var i = 0; i < n; i++)
        {
            list.RemoveAt(list.Count - 1);
        }
    }
}
