using System;
using System.Collections.Generic;

public static List<int> KSort(int[] arr, int k) {
   int n = arr.Length;
   List<int> result = new List<int>();
   
   // Create buckets for the range of possible values
   Queue<int>[] buckets = new Queue<int>[k+1];
   for (int i = 0; i <= k; i++) {
       buckets[i] = new Queue<int>();
   }
   
   // Process elements in order
   for (int i = 0; i < n; i++) {
       // Place elements in appropriate buckets
       int bucketIdx = Math.Min(k, i);
       buckets[bucketIdx].Enqueue(arr[i]);
       
       // If we have filled k+1 buckets, start extracting
       if (i >= k) {
           int minBucket = GetMinBucketIndex(buckets);
           result.Add(buckets[minBucket].Dequeue());
       }
   }
   
   // Extract remaining elements
   while (AnyBucketsNotEmpty(buckets)) {
       int minBucket = GetMinBucketIndex(buckets);
       result.Add(buckets[minBucket].Dequeue());
   }
   
   return result;
}

private static int GetMinBucketIndex(Queue<int>[] buckets) {
   int minValue = int.MaxValue;
   int minBucket = 0;
   
   for (int i = 0; i < buckets.Length; i++) {
       if (buckets[i].Count > 0 && 
           buckets[i].Peek() < minValue) {
           minValue = buckets[i].Peek();
           minBucket = i;
       }
   }
   
   return minBucket;
}

private static bool AnyBucketsNotEmpty(Queue<int>[] buckets) {
   foreach (Queue<int> bucket in buckets) {
       if (bucket.Count > 0) {
           return true;
       }
   }
   return false;
}