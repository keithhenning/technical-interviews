using System.Collections.Generic;

public class MemoizationExample
{
   private int RecursiveFunc(int m, int n, Dictionary<(int, int), int> memo)
   {
      // Create key for memo map
      var key = (m, n);

      // Check if result is already calculated
      if (memo.ContainsKey(key))
      {
         return memo[key];
      }

      // Calculate result
      int result = 0; // Replace with your actual calculation

      // Store in memo table
      memo[key] = result;
      return result;
   }
}