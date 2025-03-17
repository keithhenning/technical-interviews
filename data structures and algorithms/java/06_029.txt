/**
 * A* pathfinding with iteration limit
 */
public static List<int[]> astarWithMaxIterations(
      int[][] grid, int[] start, int[] goal, int maxIter) {
   // Track number of algorithm iterations
   int iterations = 0;
   
   // Initialize priority queue for open nodes
   PriorityQueue<Node> openSet = new PriorityQueue<>();
   openSet.add(new Node(start, 0, 
         manhattanDistance(start, goal)));
   
   // Set up other data structures
   Map<String, int[]> cameFrom = new HashMap<>();
   Map<String, Integer> gScore = new HashMap<>();
   gScore.put(Arrays.toString(start), 0);
   Set<String> closedSet = new HashSet<>();
   
   // Process nodes while available and within limit
   while (!openSet.isEmpty() && iterations < maxIter) {
      // Normal A* algorithm code would go here
      // ...
      
      // Increment iteration counter
      iterations++;
   }
   
   // Return null if path not found within iteration limit
   return null;
}