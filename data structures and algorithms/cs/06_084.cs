using System;

public class TrappingRainWater
{
   public static int Trap(int[] height)
   {
      if (height == null || height.Length == 0)
      {
         return 0;
      }

      int n = height.Length;
      int[] leftMax = new int[n];
      int[] rightMax = new int[n];

      // Fill leftMax
      leftMax[0] = height[0];
      for (int i = 1; i < n; i++)
      {
         leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
      }

      // Fill rightMax
      rightMax[n - 1] = height[n - 1];
      for (int i = n - 2; i >= 0; i--)
      {
         rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
      }

      // Calculate trapped water
      int water = 0;
      for (int i = 0; i < n; i++)
      {
         water += Math.Min(leftMax[i], rightMax[i]) - height[i];
      }

      return water;
   }

   public static void Main(string[] args)
   {
      int[] height = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
      Console.WriteLine(Trap(height));  // Output: 6
   }
}