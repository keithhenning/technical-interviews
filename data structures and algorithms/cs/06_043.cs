public static int[] FindTwoSum(int[] numbers, int target) {
    int left = 0;
    int right = numbers.Length - 1;

    while (left < right) {
        int currentSum = numbers[left] + numbers[right];
        if (currentSum == target) {
            // 1-based indexing
            return new int[] {left + 1, right + 1};
        } else if (currentSum < target) {
            left++;
        } else {
            right--;
        }
    }

    // No solution found
    return new int[] {};
}