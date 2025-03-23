/**
 * Selects a pivot using the median-of-three method.
 */
private int ChoosePivot(int[] arr, int low, int high)
{
   int mid = (low + high) / 2;

   // Find median of arr[low], arr[mid], and arr[high]
   int a = arr[low];
   int b = arr[mid];
   int c = arr[high];

   // Return the median value
   if (a > b)
   {
      if (b > c) return b;      // a > b > c
      else if (a > c) return c; // a > c > b
      else return a;            // c > a > b
   }
   else
   {
      if (a > c) return a;      // b > a > c
      else if (b > c) return c; // b > c > a
      else return b;            // c > b > a
   }
}
