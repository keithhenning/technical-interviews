import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
  public static void main(String[] args) {
     // Main method code goes here
  }
  
  /**
   * Solution class for algorithm problems
   */
  public static class Solution {
     /**
      * Find indices of two numbers that add up to target
      */
     public int[] twoSum(int[] nums, int target) {
        // Map to store numbers and their indices
        Map<Integer, Integer> seen = new HashMap<>();
        
        for (int i = 0; i < nums.length; i++) {
           // Calculate the complement needed
           int complement = target - nums[i];
           
           // Check if complement exists in map
           if (seen.containsKey(complement)) {
              return new int[] {seen.get(complement), i};
           }
           
           // Store current number and index
           seen.put(nums[i], i);
        }
        
        // No solution found
        return new int[0];
     }
  }
}