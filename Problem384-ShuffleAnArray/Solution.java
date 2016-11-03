public class Solution
{
    private int[] nums;
    private int[] original;
    private Random random;

    public Solution(int[] nums)
    {
        this.nums = nums;
        this.original = Arrays.copyOf(nums, nums.length);
        this.random = new Random();
    }

    /** Resets the array to its original configuration and return it. */
    public int[] reset() {
        return original;
    }

    /** Returns a random shuffling of the array. */
    public int[] shuffle() {
        for (int i = nums.length - 1; i > 0; i--) {
            int randomIndex = randomInRange(0, i + 1);
            int temp = nums[i];
            nums[i] = nums[randomIndex];
            nums[randomIndex] = temp;
        }
        return nums;
    }
    
    private int randomInRange(int lower, int upper) {
        return random.nextInt(upper - lower) + lower;
    }
}
