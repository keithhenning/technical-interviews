/**
 * Select appropriate heuristic based on grid movement type
 */
public static double adaptiveHeuristic(int[] a, int[] b, 
      String gridType) {
   // For grid with only cardinal directions (up/down/left/right)
   if (gridType.equals("manhattan")) {
      return Math.abs(a[0] - b[0]) + Math.abs(a[1] - b[1]);
   }
   // For grid allowing diagonal movement (8 directions)
   else if (gridType.equals("chebyshev")) {
      return Math.max(Math.abs(a[0] - b[0]), 
            Math.abs(a[1] - b[1]));
   }
   // Default case (no heuristic)
   return 0;
}