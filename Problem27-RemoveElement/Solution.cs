public class Solution {
    public int RemoveElement(int[] nums, int val)
    {
        var pushPos = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val) pushPos = Math.Min(pushPos, i);
            else nums[pushPos++] = nums[i];
        }
        return pushPos;
    }
}
