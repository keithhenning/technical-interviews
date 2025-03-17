import java.util.*;
import java.util.function.BiFunction;
import java.util.function.Function;

public class AStar {
   /**
    * Find shortest path using A* algorithm
    */
   public static List<int[]> astar(int[][] grid, int[] start, 
         int[] goal) {
      // Manhattan distance heuristic
      BiFunction<int[], int[], Integer> heuristic = (a, b) -> 
         Math.abs(a[0] - b[0]) + Math.abs(a[1] - b[1]);
      
      // Alternative Euclidean heuristic
      BiFunction<int[], int[], Double> euclideanHeuristic = 
         (a, b) -> Math.sqrt(Math.pow(a[0] - b[0], 2) + 
            Math.pow(a[1] - b[1], 2));
      
      // Get valid neighboring cells
      Function<int[], List<int[]>> getNeighbors = (pos) -> {
         int x = pos[0];
         int y = pos[1];
         // Check right, left, down, up
         int[][] directions = {
            {x+1, y}, {x-1, y}, {x, y+1}, {x, y-1}
         };
         List<int[]> neighbors = new ArrayList<>();
         
         // Return valid and walkable neighbors
         for (int[] dir : directions) {
            int newX = dir[0];
            int newY = dir[1];
            if (newX >= 0 && newX < grid.length && 
                newY >= 0 && newY < grid[0].length && 
                grid[newX][newY] != 1) {
               neighbors.add(new int[]{newX, newY});
            }
         }
         return neighbors;
      };
      
      // Comparator for priority queue based on f-score
      Comparator<int[]> fScoreComparator = (a, b) -> {
         Double aScore = fScore.getOrDefault(
            Arrays.toString(a), Double.POSITIVE_INFINITY);
         Double bScore = fScore.getOrDefault(
            Arrays.toString(b), Double.POSITIVE_INFINITY);
         return aScore.compareTo(bScore);
      };
      
      // Initialize data structures
      Set<String> openSetKeys = new HashSet<>();
      PriorityQueue<int[]> openSet = 
         new PriorityQueue<>(fScoreComparator);
      openSet.add(start);
      openSetKeys.add(Arrays.toString(start));
      Set<String> closedSet = new HashSet<>();
      
      // Track path and scores
      Map<String, int[]> cameFrom = new HashMap<>();
      Map<String, Integer> gScore = new HashMap<>();
      gScore.put(Arrays.toString(start), 0);
      Map<String, Double> fScore = new HashMap<>();
      fScore.put(Arrays.toString(start), 
         (double)heuristic.apply(start, goal));
      
      while (!openSet.isEmpty()) {
         // Get position with lowest f-score
         int[] current = openSet.poll();
         String currentKey = Arrays.toString(current);
         openSetKeys.remove(currentKey);
         
         // Check if reached goal
         if (Arrays.equals(current, goal)) {
            // Reconstruct path
            List<int[]> path = new ArrayList<>();
            path.add(current);
            while (cameFrom.containsKey(
                  Arrays.toString(current))) {
               current = cameFrom.get(Arrays.toString(current));
               path.add(0, current);
            }
            return path;
         }
         
         closedSet.add(currentKey);
         
         // Evaluate neighbors
         for (int[] neighbor : getNeighbors.apply(current)) {
            String neighborKey = Arrays.toString(neighbor);
            if (closedSet.contains(neighborKey)) {
               continue;
            }
            
            // Calculate tentative cost
            int tentativeGScore = gScore.get(currentKey) + 1;
            
            // Add to open set if new
            if (!openSetKeys.contains(neighborKey)) {
               openSet.add(neighbor);
               openSetKeys.add(neighborKey);
            } else if (tentativeGScore >= 
                  gScore.getOrDefault(neighborKey, 
                     Integer.MAX_VALUE)) {
               continue;
            }
            
            // Update path and scores
            cameFrom.put(neighborKey, current);
            gScore.put(neighborKey, tentativeGScore);
            fScore.put(neighborKey, tentativeGScore + 
               heuristic.apply(neighbor, goal));
         }
      }
      
      // No path found
      return new ArrayList<>();
   }
   
   /**
    * Print visualization of grid and path
    */
   public static void printPath(int[][] grid, List<int[]> path) {
      for (int i = 0; i < grid.length; i++) {
         for (int j = 0; j < grid[0].length; j++) {
            boolean isOnPath = false;
            for (int[] pos : path) {
               if (pos[0] == i && pos[1] == j) {
                  isOnPath = true;
                  break;
               }
            }
            
            // Print appropriate symbol
            if (i == path.get(0)[0] && j == path.get(0)[1]) {
               System.out.print("S ");  // Start
            } else if (i == path.get(path.size()-1)[0] && 
                  j == path.get(path.size()-1)[1]) {
               System.out.print("G ");  // Goal
            } else if (isOnPath) {
               System.out.print("* ");  // Path
            } else if (grid[i][j] == 1) {
               System.out.print("&#x2588; ");  // Wall
            } else {
               System.out.print(". ");  // Empty space
            }
         }
         System.out.println();
      }
   }
   
   /**
    * Test the algorithm
    */
   public static void main(String[] args) {
      // Sample grid (0=open, 1=wall)
      int[][] grid = {
         {0, 0, 0, 0, 0},
         {1, 1, 0, 1, 0},
         {0, 0, 0, 0, 0},
         {0, 1, 1, 0, 0},
         {0, 0, 0, 0, 0}
      };
      
      int[] start = {0, 0};
      int[] goal = {4, 4};
      
      // Find path
      List<int[]> path = astar(grid, start, goal);
      
      // Print results
      System.out.println("Found path:");
      for (int[] pos : path) {
         System.out.print(Arrays.toString(pos) + " ");
      }
      System.out.println("\n\nGrid visualization:");
      printPath(grid, path);
   }
}