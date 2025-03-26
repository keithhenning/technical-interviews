using System;
using System.Linq;
using System.Collections.Generic;

public class DailyTemperatures
{
   public static int[] CalculateDailyTemperatures(int[] temperatures)
   {
      int n = temperatures.Length;
      int[] result = new int[n];
      Stack<int> stack = new Stack<int>();

      for (int i = 0; i < n; i++)
      {
         while (stack.Count > 0 && temperatures[i] >
            temperatures[stack.Peek()])
         {
            int prevDay = stack.Pop();
            result[prevDay] = i - prevDay;
         }
         stack.Push(i);
      }

      return result;
   }

   public static void Main(string[] args)
   {
      int[] temps = { 73, 74, 75, 71, 69, 72, 76, 73 };
      int[] result = CalculateDailyTemperatures(temps);
      Console.WriteLine(string.Join(", ", result));
      // Output: [1, 1, 4, 2, 1, 1, 0, 0]
   }
}