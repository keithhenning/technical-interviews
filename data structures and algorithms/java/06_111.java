import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class MedianOfMedians {
   
   /**
    * Find the kth smallest element in the array
    * k is 0-based (k=0 returns smallest element)
    */
   public static int medianOfMedians(int[] arr, int k) {
      if (arr.length <= 5) {
         // Base case: sort small arrays directly
         Arrays.sort(arr);
         return arr[k];
      }
      
      // Step 1: Divide array into groups of 5 and find medians
      int numGroups = (int) Math.ceil(arr.length / 5.0);
      int[] medians = new int[numGroups];
      
      for (int i = 0; i < numGroups; i++) {
         int start = i * 5;
         int end = Math.min(start + 5, arr.length);
         int[] group = Arrays.copyOfRange(arr, start, end);
         Arrays.sort(group);
         medians[i] = group[group.length / 2];
      }
      
      // Step 2: Find median of medians recursively
      int pivot = (medians.length <= 1) 
               ? medians[0] 
               : medianOfMedians(medians, medians.length / 2);
      
      // Step 3: Partition array around the pivot
      List<Integer> left = new ArrayList<>();
      List<Integer> middle = new ArrayList<>();
      List<Integer> right = new ArrayList<>();
      
      for (int num : arr) {
         if (num < pivot) {
            left.add(num);
         } else if (num == pivot) {
            middle.add(num);
         } else {
            right.add(num);
         }
      }
      
      // Step 4: Recursively find the kth element
      if (k < left.size()) {
         return medianOfMedians(
            left.stream().mapToInt(i -> i).toArray(), k);
      } else if (k < left.size() + middle.size()) {
         return pivot;
      } else {
         return medianOfMedians(
            right.stream().mapToInt(i -> i).toArray(), 
            k - left.size() - middle.size());
      }
   }
   
   public static void main(String[] args) {
      int[] arr = {9, 1, 8, 2, 7, 3, 6, 4, 5};
      
      // Find the 4th smallest element (index 3)
      int result = medianOfMedians(arr, 3);
      System.out.println("The 4th smallest element is: " + 
         result); 
      
      // Find the median of the array
      int medianIndex = arr.length / 2;
      int median = medianOfMedians(arr, medianIndex);
      System.out.println("The median of the array is: " + 
         median);
   }
}