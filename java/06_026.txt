/**
* Calculate distance between two points for pathfinding
*/
public static double heuristic(int[] a, int[] b) {
  // Manhattan distance - faster but less precise
  return Math.abs(a[0] - b[0]) + Math.abs(a[1] - b[1]);
  
  // Euclidean distance - more accurate for diagonal 
  // movements but computationally more expensive
  // return Math.sqrt(Math.pow(a[0] - b[0], 2) + 
  //    Math.pow(a[1] - b[1], 2));
}