public static boolean comparePositions(int[] pos1, int[] pos2, int[] goal, Map<String, Double> fScore) {
   // Get f-scores for both positions
   double f1 = fScore.get(Arrays.toString(pos1));
   double f2 = fScore.get(Arrays.toString(pos2));
   
   if (f1 == f2) {
       // Prefer positions closer to goal
       double h1 = heuristic(pos1, goal);
       double h2 = heuristic(pos2, goal);
       return h1 < h2;
   }
   
   return f1 < f2;
}