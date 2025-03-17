import java.util.*;

public class KeyCollectionSequence {
   public static int minimumStepsToCollectKeys(
         String[] maze) {
      int rows = maze.length;
      int cols = maze[0].length();
      
      // Find start and keys
      int startRow = 0, startCol = 0;
      List<Character> keys = new ArrayList<>();
      
      for (int r = 0; r < rows; r++) {
         for (int c = 0; c < cols; c++) {
            char cell = maze[r].charAt(c);
            if (cell == 'S') {
               startRow = r;
               startCol = c;
            } else if ('a' <= cell && cell <= 'z') {
               keys.add(cell);
            }
         }
      }
      
      // Sort keys alphabetically
      Collections.sort(keys);
      
      // Movement directions
      int[][] directions = {{-1, 0}, {0, 1}, 
                             {1, 0}, {0, -1}};
      
      // Track current position
      int currRow = startRow, currCol = startCol;
      int totalSteps = 0;
      Set<Character> collectedKeys = new HashSet<>();
      
      // Collect keys in order
      for (char key : keys) {
         // BFS to find key path
         Queue<int[]> queue = new LinkedList<>();
         queue.add(new int[]{currRow, currCol, 0});
         Set<String> visited = new HashSet<>();
         visited.add(currRow + "," + currCol);
         boolean found = false;
         
         while (!queue.isEmpty() && !found) {
            int[] curr = queue.poll();
            int r = curr[0], c = curr[1], steps = curr[2];
            
            // Key found
            if (maze[r].charAt(c) == key) {
               totalSteps += steps;
               currRow = r;
               currCol = c;
               collectedKeys.add(key);
               found = true;
               break;
            }
            
            // Try all directions
            for (int[] dir : directions) {
               int nr = r + dir[0], nc = c + dir[1];
               
               // Validate new position
               if (0 <= nr && nr < rows && 
                   0 <= nc && nc < cols && 
                   maze[nr].charAt(nc) != '#' && 
                   !visited.contains(nr + "," + nc)) {
                  
                  // Check door keys
                  char cell = maze[nr].charAt(nc);
                  if ('A' <= cell && cell <= 'Z') {
                     char keyNeeded = 
                        Character.toLowerCase(cell);
                     if (!collectedKeys.contains(
                           keyNeeded)) {
                        continue;
                     }
                  }
                  
                  queue.add(new int[]{nr, nc, 
                                      steps + 1});
                  visited.add(nr + "," + nc);
               }
            }
         }
         
         // Key unreachable
         if (!found) {
            return -1;
         }
      }
      
      return totalSteps;
   }
}