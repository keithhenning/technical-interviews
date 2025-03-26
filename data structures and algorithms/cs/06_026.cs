/**
* Calculate distance between two points for pathfinding
*/
public static double Heuristic(int[] a, int[] b)
{
   // Manhattan distance - faster but less precise
   return Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]);

   // Euclidean distance - more accurate for diagonal 
   // movements but computationally more expensive
   // return Math.Sqrt(Math.Pow(a[0] - b[0], 2) + 
   //    Math.Pow(a[1] - b[1], 2));
}
