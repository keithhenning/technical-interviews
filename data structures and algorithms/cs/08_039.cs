using System.Collections.Generic;

public class ProductivityZoneCalculator
{
   public static int MaxProductivityZone(int[] capacities)
   {
      var stack = new Stack<int>();
      int maxArea = 0;
      int n = capacities.Length;

      for (int i = 0; i < n; i++)
      {
         while (stack.Count > 0 &&
            capacities[stack.Peek()] > capacities[i])
         {
            int height = capacities[stack.Pop()];
            int width = stack.Count == 0 ? i :
               i - stack.Peek() - 1;
            maxArea = Math.Max(maxArea, height * width);
         }

         stack.Push(i);
      }

      while (stack.Count > 0)
      {
         int height = capacities[stack.Pop()];
         int width = stack.Count == 0 ? n :
            n - stack.Peek() - 1;
         maxArea = Math.Max(maxArea, height * width);
      }

      return maxArea;
   }
}