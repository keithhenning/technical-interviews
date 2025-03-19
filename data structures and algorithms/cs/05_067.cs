using System;
using System.Collections.Generic;

public class MainClass {
  public static void Main(string[] args) {
     // Main method code goes here
  }
  
  /**
   * Solution class for algorithm problems
   */
  public static class Solution {
     /**
      * Find indices of two numbers that add up to target
      */
     public static int[] TwoSum(int[] nums, int target) {
        // Map to store numbers and their indices
        Dictionary<int, int> seen = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++) {
           // Calculate the complement needed
           int complement = target - nums[i];
           
           // Check if complement exists in map
           if (seen.ContainsKey(complement)) {
              return new int[] {seen[complement], i};
           }
           
           // Store current number and index
           seen[nums[i]] = i;
        }
        
        // No solution found
        return new int[0];
     }
  }
}
