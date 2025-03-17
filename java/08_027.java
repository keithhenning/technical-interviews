import java.util.HashMap;
import java.util.Map;

/**
 * Finds maximum length subarray with a target sum
 */
public class MaximumSubarrayWithTargetSum {
   /**
    * Find length of longest subarray with sum equal to target
    */
   public static int maxSubarrayWithTargetSum(int[] nums, 
         int target) {
      // Track first occurrence of each cumulative sum
      Map<Integer, Integer> sumIndexMap = new HashMap<>();
      sumIndexMap.put(0, -1); // Sum 0 at position -1
      
      int maxLength = 0;
      int currentSum = 0;
      
      for (int i = 0; i < nums.length; i++) {
         // Update running sum
         currentSum += nums[i];
         
         // Check if we can form target sum subarray
         if (sumIndexMap.containsKey(currentSum - target)) {
            int subarrayStart = sumIndexMap.get(currentSum - target) + 1;
            int currentLength = i - subarrayStart + 1;
            maxLength = Math.max(maxLength, currentLength);
         }
         
         // Only store first occurrence of each sum
         if (!sumIndexMap.containsKey(currentSum)) {
            sumIndexMap.put(currentSum, i);
         }
      }
      
      return maxLength;
   }
   
   /**
    * Test the algorithm
    */
   public static void main(String[] args) {
      int[] nums = {1, -1, 5, -2, 3, 0, 2, -4, 1};
      int target = 3;
      int result = maxSubarrayWithTargetSum(nums, target);
      System.out.println("Maximum subarray length: " + result);
   }
}