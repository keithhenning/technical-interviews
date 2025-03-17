import java.util.ArrayList;
import java.util.List;

/**
 * Efficiently query elements from a rotated circular array
 */
public class CircularArrayRotation {
   
   /**
    * Query elements after array rotations
    */
   public static List<Integer> queryRotatedArray(int[] arr, 
         int[][] queries) {
      int n = arr.length;
      List<Integer> results = new ArrayList<>();
      
      for (int[] query : queries) {
         int rotation = query[0];
         int index = query[1];
         
         // Calculate effective rotation (handle large values)
         int effectiveRotation = rotation % n;
         
         // Find original position before rotation
         int originalPosition = (index - effectiveRotation + n) % n;
         results.add(arr[originalPosition]);
      }
      
      return results;
   }
   
   public static void main(String[] args) {
      int[] arr = {3, 7, 1, 9, 5};
      int[][] queries = {{2, 1}, {4, 3}, {0, 2}};
      
      List<Integer> results = queryRotatedArray(arr, queries);
      System.out.println(results); // Output: [3, 3, 1]
   }
}