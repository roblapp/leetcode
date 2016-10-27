public class Solution
{
    public void NextPermutation(int[] nums)
    {
        var n = nums.Length;
        var j = n - 2;
        var k = n - 1;

        /* j is the largest a_j such that a[j] <= a[j+1] */
        while (j >= 0 && nums[j] >= nums[j + 1])
            j--;

        if (j == -1)
        {
            Array.Reverse(nums);
            return;
        }

        /* a[k] is the smallest integer greater than a[j] to the right of a[j] */
        while (k >= 0 && nums[j] >= nums[k])
            k--;

        Swap(ref nums[j], ref nums[k]);

        var r = n - 1;
        var s = j + 1;

        while (r > s)
        {
            Swap(ref nums[r], ref nums[s]);
            r--;
            s++;
        }
    }

    private static void Swap<T>(ref T a, ref T b)
    {
        var temp = a;
        a = b;
        b = temp;
    }
}
