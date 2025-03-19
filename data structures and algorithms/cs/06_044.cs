public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if (nums.Length == 0) return 0;

        int slow = 0;

        for (int fast = 1; fast < nums.Length; fast++) {
            if (nums[fast] != nums[slow]) {
                slow++;
                nums[slow] = nums[fast];
            }
        }

        return slow + 1;
    }
}