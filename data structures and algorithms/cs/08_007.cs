using System.Collections.Generic;

public class SlidingWindowExtremaProduct
{
   public int[] FindExtremaProducts(
      int[] prices,
      int k)
   {
      int n = prices.Length;
      if (n == 0 || k == 0 || k > n)
      {
         return new int[0];
      }

      int[] result = new int[n - k + 1];
      var maxList = new List<int>();
      var minList = new List<int>();

      // Process first window
      for (int i = 0; i < k; i++)
      {
         // Remove smaller elements from maxList
         while (maxList.Count > 0 &&
            prices[i] >= prices[maxList[maxList.Count - 1]])
         {
            maxList.RemoveAt(maxList.Count - 1);
         }
         maxList.Add(i);

         // Remove larger elements from minList
         while (minList.Count > 0 &&
            prices[i] <= prices[minList[minList.Count - 1]])
         {
            minList.RemoveAt(minList.Count - 1);
         }
         minList.Add(i);
      }

      // Calculate first window product
      result[0] = prices[maxList[0]] *
         prices[minList[0]];

      // Process remaining windows
      for (int i = k; i < n; i++)
      {
         // Remove elements outside window
         while (maxList.Count > 0 &&
            maxList[0] <= i - k)
         {
            maxList.RemoveAt(0);
         }
         while (minList.Count > 0 &&
            minList[0] <= i - k)
         {
            minList.RemoveAt(0);
         }

         // Remove smaller elements from maxList
         while (maxList.Count > 0 &&
            prices[i] >= prices[maxList[maxList.Count - 1]])
         {
            maxList.RemoveAt(maxList.Count - 1);
         }
         maxList.Add(i);

         // Remove larger elements from minList
         while (minList.Count > 0 &&
            prices[i] <= prices[minList[minList.Count - 1]])
         {
            minList.RemoveAt(minList.Count - 1);
         }
         minList.Add(i);

         // Calculate current window product
         result[i - k + 1] = prices[maxList[0]] *
            prices[minList[0]];
      }

      return result;
   }
}