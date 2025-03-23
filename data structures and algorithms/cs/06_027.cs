/**
 * Select appropriate heuristic based on grid movement type
 */
public static double AdaptiveHeuristic(int[] a, int[] b, string gridType)
{
   // For grid with only cardinal directions (up/down/left/right)
   if (gridType == "manhattan")
   {
      return Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]);
   }
   // For grid allowing diagonal movement (8 directions)
   else if (gridType == "chebyshev")
   {
      return Math.Max(Math.Abs(a[0] - b[0]), Math.Abs(a[1] - b[1]));
   }
   // Default case (no heuristic)
   return 0;
}
