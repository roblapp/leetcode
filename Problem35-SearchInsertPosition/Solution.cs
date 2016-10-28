public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        return LowerBound(nums, target);
    }

    public static int LowerBound<T>(T[] a, T x)
        where T : IComparable<T>
    {
        var low = 0;
        var high = a.Length;

        while (low < high)
        {
            var mid = low + (high - low) / 2;
            //Note: the <= here is what makes this work.
            //Tradtional binary search has a case if (a[mid] == val) return mid;
            //But we are looking for the first number smaller than some number X

            if (x.CompareTo(a[mid]) <= 0)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }
        return low;
    }
}
