public class Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var resultList = new List<IList<int>>();
        Array.Sort(nums);
        resultList.Add(nums.ToList());
        while (NextPermutation(nums, nums.Length))
        {
            resultList.Add(nums.ToList());
        }

        return resultList;
    }

    public static bool NextPermutation(int[] a, int n)
    {
        var j = n - 2;
        var k = n - 1;

        /* j is the largest a_j such that a[j] <= a[j+1] */
        while (j >= 0 && a[j] >= a[j + 1])
            j--;

        //Console.WriteLine("j = {0}", j);

        if (j == -1) return false;

        /* a[k] is the smallest integer greater than a[j] to the right of a[j] */
        while (k >= 0 && a[j] >= a[k])
            k--;

        //Console.WriteLine("k = {0}", k);

        Swap(ref a[j], ref a[k]);

        var r = n - 1;
        var s = j + 1;

        while (r > s)
        {
            Swap(ref a[r], ref a[s]);
            r--;
            s++;
        }
        return true;
    }

    public static void Swap(ref int a, ref int b)
    {
        var temp = a;
        a = b;
        b = temp;
    }
}
