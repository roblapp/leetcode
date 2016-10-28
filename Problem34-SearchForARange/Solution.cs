public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        if (Array.BinarySearch(nums, target) < 0) return new[] {-1, -1};
        
        var x = LowerBound(nums, target);
        var y = UpperBound(nums, target);

        return new[] {x, y-1};
    }

    public static int UpperBound<T>(T[] a, T x)
        where T : IComparable<T>
    {
        var low = 0;
        var high = a.Length;

        while (low < high)
        {
            var mid = low + (high - low) / 2;
            if (x.CompareTo(a[mid]) >= 0)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }
        return low;
    }

    public static int LowerBound<T>(T[] a, T x)
        where T : IComparable<T>
    {
        var low = 0;
        var high = a.Length;

        while (low < high)
        {
            var mid = low + (high - low) / 2;
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
