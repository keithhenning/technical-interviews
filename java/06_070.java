import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class BucketSort {
   public static void bucketSort(float[] arr) {
       if (arr == null || arr.length <= 1) return;
       
       // Create buckets
       int n = arr.length;
       List<Float>[] buckets = new ArrayList[n];
       for (int i = 0; i < n; i++) {
           buckets[i] = new ArrayList<>();
       }
       
       // Find range for bucket distribution
       float maxVal = arr[0], minVal = arr[0];
       for (float num : arr) {
           maxVal = Math.max(maxVal, num);
           minVal = Math.min(minVal, num);
       }
       
       // Distribute elements
       for (float num : arr) {
           int index = (int)((num - minVal) * (n - 1) / 
                             (maxVal - minVal));
           buckets[index].add(num);
       }
       
       // Sort individual buckets
       for (List<Float> bucket : buckets) {
           Collections.sort(bucket);
       }
       
       // Concatenate results
       int index = 0;
       for (List<Float> bucket : buckets) {
           for (float num : bucket) {
               arr[index++] = num;
           }
       }
   }
}