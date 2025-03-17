class Solution {
    public int minMaxGroupSum(int[] nums, int k) {
        int left = Integer.MIN_VALUE;
        int right = 0;
        
        // Calculate the search boundaries
        for (int num : nums) {
            left = Math.max(left, num);
            right += num;
        }
        
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (canSplit(nums, k, mid)) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        
        return left;
    }
    
    private boolean canSplit(int[] nums, int k, int threshold) {
        int groups = 1;
        int currentSum = 0;
        
        for (int num : nums) {
            // If a single element exceeds threshold, 
            // splitting is impossible
            if (num > threshold) {
                return false;
            }
            
            // Try adding the current number to the current group
            if (currentSum + num <= threshold) {
                currentSum += num;
            } else {
                // Start a new group
                groups++;
                currentSum = num;
                
                // If we need more than k groups, return false
                if (groups > k) {
                    return false;
                }
            }
        }
        
        return true;
    }
}