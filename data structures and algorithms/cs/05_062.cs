using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   // For Two Sum
   public int[] TwoSum(int[] nums, int target)
   {
      if (nums == null || nums.Length < 2)
      {
         return new int[0];
      }

      Dictionary<int, int> map = new Dictionary<int, int>();

      for (int i = 0; i < nums.Length; i++)
      {
         int complement = target - nums[i];
         if (map.ContainsKey(complement))
         {
            return new int[] { map[complement], i };
         }
         if (!map.ContainsKey(nums[i]))
         {
            map.Add(nums[i], i);
         }
      }

      return new int[0];
   }

   public void PrintArray(int[] array)
   {
      foreach (int item in array)
      {
         Console.Write(item + " ");
      }
      Console.WriteLine();
   }
}
