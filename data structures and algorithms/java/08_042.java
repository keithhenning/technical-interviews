public int findMinimum(int[] nums) {
    int left = 0;
    int right = nums.length - 1;
    
    // Already sorted case
    if (nums[left] <= nums[right]) {
        return nums[left];
    }
    
    while (left < right) {
        int mid = left + (right - left) / 2;
        
        if (nums[mid] > nums[right]) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    
    return nums[left];
}