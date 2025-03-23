public class LinearTime {
   public static int FindMaximum(int[] arr) {
      // Check for empty array
      if (arr.Length == 0) {
         throw new ArgumentException(
            "Array cannot be empty");
      }

      int maxValue = arr[0];
      foreach (int num in arr) {
         if (num > maxValue) {
            maxValue = num;
         }
      }
      return maxValue;
   }

   public static void Main(string[] args) {
      int[] numbers = {3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5};
      Console.WriteLine("Maximum value: " + 
         FindMaximum(numbers));  // Output: 9
   }
}