using System;
using System.Collections.Generic;

public class TwoSum {
    public static int[] FindTwoSum(int[] nums, int target) {
        Dictionary<int, int> numMap = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++) {
            int complement = target - nums[i];
            
            if (numMap.ContainsKey(complement)) {
                return new int[]{numMap[complement], i};
            }
            
            numMap[nums[i]] = i;
        }
        
        return null;  // No solution found
    }
    
    public static void Main(string[] args) {
        Console.WriteLine(string.Join(", ", FindTwoSum(new int[]{2, 7, 11, 15}, 9)));  // [0, 1]
        Console.WriteLine(string.Join(", ", FindTwoSum(new int[]{3, 2, 4}, 6)));       // [1, 2]
    }
}