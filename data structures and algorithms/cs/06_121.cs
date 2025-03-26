public class Solution
{
   public static int[] Solution(int n, int[] a)
   {
      int[] result = new int[n];
      for (int i = 0; i < n; i++)
      {
         int leftValue = (i > 0) ? a[i - 1] : 0;
         int rightValue = (i < n - 1) ? a[i + 1] : 0;
         result[i] = leftValue + a[i] + rightValue;
      }
      return result;
   }
}
