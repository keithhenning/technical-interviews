public class ClearanceCodeFinder
{
   public static bool FindClearanceCode(
      int[][] matrix,
      int target
   )
   {
      if (matrix == null ||
         matrix.Length == 0 ||
         matrix[0].Length == 0)
      {
         return false;
      }

      int rows = matrix.Length;
      int cols = matrix[0].Length;
      int left = 0;
      int right = rows * cols - 1;

      while (left <= right)
      {
         int mid = left + (right - left) / 2;
         int row = mid / cols;
         int col = mid % cols;

         if (matrix[row][col] == target)
         {
            return true;
         }
         else if (matrix[row][col] < target)
         {
            left = mid + 1;
         }
         else
         {
            right = mid - 1;
         }
      }

      return false;
   }
}