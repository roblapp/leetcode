public class Solution {
    public int RemoveDuplicates(int[] nums)
    {
        var result = 0;

        if (nums.Length == 0) return result;

        var pushPos = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                nums[pushPos++] = nums[i];
                result++;
            }
        }
        return result + 1;
    }
}
