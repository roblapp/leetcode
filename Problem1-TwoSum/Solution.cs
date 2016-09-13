public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var diff = target - nums[i];
            if (map.ContainsKey(diff))
            {
                //Note map[diff] comes first because it will be smaller
                return new int[] { map[diff], i };
            }
            map[nums[i]] = i;
        }
        throw new ArgumentException("No solution");
    }
}
