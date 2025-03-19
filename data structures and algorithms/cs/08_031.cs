using System.Collections.Generic;

public class RangeDuplicateFinder {
    public static bool HasNearbyDuplicates(int[] nums, int k) {
        var window = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++) {
            if (i >= k) {
                window.Remove(nums[i - k]);
            }

            if (window.Contains(nums[i])) {
                return true;
            }

            window.Add(nums[i]);
        }

        return false;
    }
}