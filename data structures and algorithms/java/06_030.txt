/**
* Bidirectional A* search from start and goal
*/
public static List<int[]> bidirectionalAstar(int[][] grid, 
     int[] start, int[] goal) {
  // Initialize forward search front (from start)
  Map<String, Integer> forwardFront = new HashMap<>();
  forwardFront.put(Arrays.toString(start), 0);
  Map<String, int[]> forwardParents = new HashMap<>();
  
  // Initialize backward search front (from goal)
  Map<String, Integer> backwardFront = new HashMap<>();
  backwardFront.put(Arrays.toString(goal), 0);
  Map<String, int[]> backwardParents = new HashMap<>();
  
  // Search until fronts meet or are exhausted
  while (!forwardFront.isEmpty() && 
        !backwardFront.isEmpty()) {
     // Expand the smaller front first for efficiency
     String current;
     if (forwardFront.size() < backwardFront.size()) {
        current = expandFront(forwardFront, forwardParents, 
              grid, goal, true);
     } else {
        current = expandFront(backwardFront, backwardParents, 
              grid, start, false);
     }
     
     // Check if fronts have met at current position
     if (forwardFront.containsKey(current) && 
           backwardFront.containsKey(current)) {
        return reconstructPath(current, forwardParents, 
              backwardParents);
     }
  }
  
  // No path found
  return null;
}