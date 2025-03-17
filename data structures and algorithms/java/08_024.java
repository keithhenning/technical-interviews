import java.util.*;

public class DynamicMazeFloodFill {
   /**
    * Position in the maze with time tracking
    */
   static class Position {
      int x, y, time;
      
      Position(int x, int y, int time) {
         this.x = x;
         this.y = y;
         this.time = time;
      }
   }
   
   /**
    * Find shortest path through maze using BFS
    */
   public static int floodFillTime(int[][] maze, int startX, 
         int startY, int targetX, int targetY) {
      int rows = maze.length;
      int cols = maze[0].length;
      boolean[][] visited = new boolean[rows][cols];
      
      // Queue for BFS traversal
      Queue<Position> queue = new LinkedList<>();
      queue.add(new Position(startX, startY, 0));
      visited[startX][startY] = true;
      
      // Four possible movement directions
      int[][] directions = {{1, 0}, {-1, 0}, {0, 1}, {0, -1}};
      
      while (!queue.isEmpty()) {
         Position current = queue.poll();
         
         // Check if target reached
         if (current.x == targetX && current.y == targetY) {
            return current.time;
         }
         
         // Try all four directions
         for (int[] dir : directions) {
            int nx = current.x + dir[0];
            int ny = current.y + dir[1];
            
            // Check if move is valid
            if (nx >= 0 && nx < rows && ny >= 0 && ny < cols && 
                !visited[nx][ny] && maze[nx][ny] == 0) {
               visited[nx][ny] = true;
               queue.add(new Position(nx, ny, current.time + 1));
            }
         }
      }
      
      return -1;  // Target not reachable
   }
   
   /**
    * Test the flood fill algorithm
    */
   public static void main(String[] args) {
      int[][] maze = {
         {0, 0, 0, 0},
         {1, 1, 0, 1},
         {0, 2, 0, 0},
         {0, 1, 1, 0}
      };
      
      int result = floodFillTime(maze, 2, 1, 0, 0);
      System.out.println("Shortest path length: " + result);
   }
}