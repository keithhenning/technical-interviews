using System;
using System.Collections.Generic;

public static float[] BucketSortFloat(float[] arr)
{
   int n = arr.Length;
   List<List<float>> buckets = new List<List<float>>(n);

   // Initialize buckets
   for (int i = 0; i < n; i++)
   {
      buckets.Add(new List<float>());
   }

   // Place elements into buckets
   foreach (float num in arr)
   {
      int bucketIdx = (int)(n * num);
      buckets[bucketIdx].Add(num);
   }

   // Sort individual buckets
   foreach (List<float> bucket in buckets)
   {
      // Can use insertion sort for small buckets
      bucket.Sort();
   }

   // Concatenate all buckets
   float[] result = new float[n];
   int index = 0;
   foreach (List<float> bucket in buckets)
   {
      foreach (float num in bucket)
      {
         result[index++] = num;
      }
   }

   return result;
}