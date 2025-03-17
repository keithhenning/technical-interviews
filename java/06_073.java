import java.util.ArrayList;
import java.util.ArrayDeque;
import java.util.Deque;
import java.util.List;

public static List<Integer> kSort(int[] arr, int k) {
   int n = arr.length;
   List<Integer> result = new ArrayList<>();
   
   // Create buckets for the range of possible values
   Deque<Integer>[] buckets = new ArrayDeque[k+1];
   for (int i = 0; i <= k; i++) {
       buckets[i] = new ArrayDeque<>();
   }
   
   // Process elements in order
   for (int i = 0; i < n; i++) {
       // Place elements in appropriate buckets
       int bucketIdx = Math.min(k, i);
       buckets[bucketIdx].addLast(arr[i]);
       
       // If we have filled k+1 buckets, start extracting
       if (i >= k) {
           int minBucket = getMinBucketIndex(buckets);
           result.add(buckets[minBucket].removeFirst());
       }
   }
   
   // Extract remaining elements
   while (anyBucketsNotEmpty(buckets)) {
       int minBucket = getMinBucketIndex(buckets);
       result.add(buckets[minBucket].removeFirst());
   }
   
   return result;
}

private static int getMinBucketIndex(Deque<Integer>[] buckets) {
   int minValue = Integer.MAX_VALUE;
   int minBucket = 0;
   
   for (int i = 0; i < buckets.length; i++) {
       if (!buckets[i].isEmpty() && 
           buckets[i].peekFirst() < minValue) {
           minValue = buckets[i].peekFirst();
           minBucket = i;
       }
   }
   
   return minBucket;
}

private static boolean anyBucketsNotEmpty(
       Deque<Integer>[] buckets) {
   for (Deque<Integer> bucket : buckets) {
       if (!bucket.isEmpty()) {
           return true;
       }
   }
   return false;
}