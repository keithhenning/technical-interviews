public class LinearTime {
  public static int findMaximum(int[] arr) {
     // Check for empty array
     if (arr.length == 0) {
        throw new IllegalArgumentException(
           "Array cannot be empty");
     }
     
     int maxValue = arr[0];
     for (int num : arr) {
        if (num > maxValue) {
           maxValue = num;
        }
     }
     return maxValue;
  }

  public static void main(String[] args) {
     int[] numbers = {3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5};
     System.out.println("Maximum value: " + 
        findMaximum(numbers));  // Output: 9
  }
}