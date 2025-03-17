import java.util.*;

public class AStar {
   /**
    * Calculate Manhattan distance between two points
    */
   public static int manhattanDistance(int[] a, int[] b) {
      return Math.abs(a[0] - b[0]) + Math.abs(a[1] - b[1]);
   }

   /**
    * Get valid neighboring positions
    */
   public static List<int[]> getNeighbors(int[] pos, 
         int[][] grid) {
      List<int[]> neighbors = new ArrayList<>();
      // Right, down, left, up
      int[][] directions = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}}; 
      
      for (int[] dir : directions) {
         int newX = pos[0] + dir[0];
         int newY = pos[1] + dir[1];
         
         // Check if position is valid (1 = wall)
         if (newX >= 0 && newX < grid.length && 
             newY >= 0 && newY < grid[0].length && 
             grid[newX][newY] != 1) {
            neighbors.add(new int[]{newX, newY});
         }
      }
      return neighbors;
   }

   /**
    * A* pathfinding algorithm
    * Returns path from start to goal if found
    */
   public static List<int[]> aStar(int[][] grid, int[] start, 
         int[] goal) {
      // Priority queue for open nodes
      PriorityQueue<Node> openSet = new PriorityQueue<>();
      openSet.add(new Node(start, 0, 
            manhattanDistance(start, goal)));
      
      // Track previous node in optimal path
      Map<String, int[]> cameFrom = new HashMap<>();
      
      // Cost from start to each node
      Map<String, Integer> gScore = new HashMap<>();
      gScore.put(Arrays.toString(start), 0);
      
      // Set of visited nodes
      Set<String> closedSet = new HashSet<>();
      
      while (!openSet.isEmpty()) {
         Node current = openSet.poll();
         int[] currentPos = current.position;
         String currentKey = Arrays.toString(currentPos);
         
         // Check if reached goal
         if (Arrays.equals(currentPos, goal)) {
            // Reconstruct path
            List<int[]> path = new ArrayList<>();
            path.add(currentPos);
            while (cameFrom.containsKey(currentKey)) {
               currentPos = cameFrom.get(currentKey);
               currentKey = Arrays.toString(currentPos);
               path.add(0, currentPos);
            }
            return path;
         }
         
         closedSet.add(currentKey);
         
         // Check all neighbors
         for (int[] neighbor : getNeighbors(currentPos, grid)) {
            String neighborKey = Arrays.toString(neighbor);
            
            // Skip if already evaluated
            if (closedSet.contains(neighborKey)) {
               continue;
            }
            
            // Assume cost of 1 to move to adjacent square
            int tentativeGScore = gScore.get(currentKey) + 1;
            
            // Found better path to neighbor
            if (!gScore.containsKey(neighborKey) || 
                  tentativeGScore < gScore.get(neighborKey)) {
               cameFrom.put(neighborKey, currentPos);
               gScore.put(neighborKey, tentativeGScore);
               int fScore = tentativeGScore + 
                     manhattanDistance(neighbor, goal);
               openSet.add(new Node(neighbor, 
                     tentativeGScore, fScore));
            }
         }
      }
      
      // No path found
      return new ArrayList<>();
   }

   /**
    * Node class for the priority queue
    */
   static class Node implements Comparable<Node> {
      int[] position;
      int gScore;
      int fScore;
      
      public Node(int[] position, int gScore, int fScore) {
         this.position = position;
         this.gScore = gScore;
         this.fScore = fScore;
      }
      
      @Override
      public int compareTo(Node other) {
         return Integer.compare(this.fScore, other.fScore);
      }
   }

   /**
    * Create visual representation of the path
    */
   public static String visualizePath(int[][] grid, 
         List<int[]> path, int[] start, int[] goal) {
      StringBuilder visual = new StringBuilder();
      
      for (int i = 0; i < grid.length; i++) {
         for (int j = 0; j < grid[0].length; j++) {
            boolean isOnPath = false;
            // Check if current position is on path
            for (int[] pos : path) {
               if (pos[0] == i && pos[1] == j) {
                  isOnPath = true;
                  break;
               }
            }
            
            // Choose appropriate symbol
            if (i == start[0] && j == start[1]) {
               visual.append("S ");
            } else if (i == goal[0] && j == goal[1]) {
               visual.append("G ");
            } else if (isOnPath) {
               visual.append("* ");
            } else if (grid[i][j] == 1) {
               visual.append("&#x2588; ");
            } else {
               visual.append(". ");
            }
         }
         visual.append("\n");
      }
      
      return visual.toString();
   }

   /**
    * Example usage
    */
   public static void main(String[] args) {
      // 0 = empty space, 1 = wall
      int[][] grid = {
         {0, 0, 0, 0, 1},
         {1, 1, 0, 1, 0},
         {0, 0, 0, 0, 0},
         {0, 1, 1, 1, 0},
         {0, 0, 0, 1, 0}
      };
      
      int[] start = {0, 0};
      int[] goal = {4, 4};
      
      // Find path using A*
      List<int[]> path = aStar(grid, start, goal);
      
      // Print path coordinates
      System.out.print("Path found: ");
      for (int[] pos : path) {
         System.out.print(Arrays.toString(pos) + " ");
      }
      
      // Print grid visualization
      System.out.println("\n\nGrid visualization:");
      System.out.println(visualizePath(grid, path, 
            start, goal));
   }
}