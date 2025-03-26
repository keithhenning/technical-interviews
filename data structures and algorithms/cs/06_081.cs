using System;
using System.Linq;
using System.Collections.Generic;

public class MonotonicStack
{
   public static int[] NextGreaterElement(int[] nums)
   {
      int n = nums.Length;
      int[] result = new int[n];
      Array.Fill(result, -1);  // Initialize with -1

      Stack<int> stack = new Stack<int>();

      for (int i = 0; i < n; i++)
      {
         // Maintain monotonic decreasing property of the stack
         while (stack.Count > 0 && nums[i] > nums[stack.Peek()])
         {
            int popped = stack.Pop();
            result[popped] = nums[i];
         }

         stack.Push(i);
      }

      return result;
   }

   public static void Main(string[] args)
   {
      int[] nums = { 4, 5, 2, 10, 8 };
      int[] result = NextGreaterElement(nums);
      Console.WriteLine(string.Join(", ", result));  // Output: [5, 10, 10, -1, -1]
   }
}