using System;
using System.Collections.Generic;
using System.Linq;

public class BucketSort
{
   public static void Sort(float[] arr)
   {
      if (arr == null || arr.Length <= 1) return;

      int n = arr.Length;
      List<float>[] buckets = new List<float>[n];

      for (int i = 0; i < n; i++)
      {
         buckets[i] = new List<float>();
      }

      float maxVal = arr.Max();
      float minVal = arr.Min();

      foreach (float num in arr)
      {
         int index = (int)((num - minVal) * (n - 1) / (maxVal - minVal));
         buckets[index].Add(num);
      }

      foreach (var bucket in buckets)
      {
         bucket.Sort();
      }

      int currentIndex = 0;
      foreach (var bucket in buckets)
      {
         foreach (var num in bucket)
         {
            arr[currentIndex++] = num;
         }
      }
   }
}
