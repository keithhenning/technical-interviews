using System;
using System.Collections.Generic;

public class AStar
{
   /**
    * Calculate Manhattan distance between two points
    */
   public static int ManhattanDistance(int[] a, int[] b)
   {
      return Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]);
   }

   /**
    * Get valid neighboring positions
    */
   public static List<int[]> GetNeighbors(int[] pos, int[][] grid)
   {
      List<int[]> neighbors = new List<int[]>();
      // Right, down, left, up
      int[][] directions = { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

      foreach (int[] dir in directions)
      {
         int newX = pos[0] + dir[0];
         int newY = pos[1] + dir[1];

         // Check if position is valid (1 = wall)
         if (newX >= 0 && newX < grid.Length &&
             newY >= 0 && newY < grid[0].Length &&
             grid[newX][newY] != 1)
         {
            neighbors.Add(new int[] { newX, newY });
         }
      }
      return neighbors;
   }

   /**
    * A* pathfinding algorithm
    * Returns path from start to goal if found
    */
   public static List<int[]> AStarPathfinding(int[][] grid, int[] start, int[] goal)
   {
      // Priority queue for open nodes
      PriorityQueue<Node> openSet = new PriorityQueue<Node>();
      openSet.Enqueue(new Node(start, 0, ManhattanDistance(start, goal)));

      // Track previous node in optimal path
      Dictionary<string, int[]> cameFrom = new Dictionary<string, int[]>();

      // Cost from start to each node
      Dictionary<string, int> gScore = new Dictionary<string, int>();
      gScore[JsonConvert.SerializeObject(start)] = 0;

      // Set of visited nodes
      HashSet<string> closedSet = new HashSet<string>();

      while (openSet.Count > 0)
      {
         Node current = openSet.Dequeue();
         int[] currentPos = current.Position;
         string currentKey = JsonConvert.SerializeObject(currentPos);

         // Check if reached goal
         if (currentPos.SequenceEqual(goal))
         {
            // Reconstruct path
            List<int[]> path = new List<int[]>();
            path.Add(currentPos);
            while (cameFrom.ContainsKey(currentKey))
            {
               currentPos = cameFrom[currentKey];
               currentKey = JsonConvert.SerializeObject(currentPos);
               path.Insert(0, currentPos);
            }
            return path;
         }

         closedSet.Add(currentKey);

         // Check all neighbors
         foreach (int[] neighbor in GetNeighbors(currentPos, grid))
         {
            string neighborKey = JsonConvert.SerializeObject(neighbor);

            // Skip if already evaluated
            if (closedSet.Contains(neighborKey))
            {
               continue;
            }

            // Assume cost of 1 to move to adjacent square
            int tentativeGScore = gScore[currentKey] + 1;

            // Found better path to neighbor
            if (!gScore.ContainsKey(neighborKey) ||
                  tentativeGScore < gScore[neighborKey])
            {
               cameFrom[neighborKey] = currentPos;
               gScore[neighborKey] = tentativeGScore;
               int fScore = tentativeGScore +
                     ManhattanDistance(neighbor, goal);
               openSet.Enqueue(new Node(neighbor,
                     tentativeGScore, fScore));
            }
         }
      }

      // No path found
      return new List<int[]>();
   }

   /**
    * Node class for the priority queue
    */
   public class Node : IComparable<Node>
   {
      public int[] Position { get; }
      public int GScore { get; }
      public int FScore { get; }

      public Node(int[] position, int gScore, int fScore)
      {
         Position = position;
         GScore = gScore;
         FScore = fScore;
      }

      public int CompareTo(Node other)
      {
         return FScore.CompareTo(other.FScore);
      }
   }

   /**
    * Create visual representation of the path
    */
   public static string VisualizePath(int[][] grid, List<int[]> path, int[] start, int[] goal)
   {
      StringBuilder visual = new StringBuilder();

      for (int i = 0; i < grid.Length; i++)
      {
         for (int j = 0; j < grid[0].Length; j++)
         {
            bool isOnPath = false;
            // Check if current position is on path
            foreach (int[] pos in path)
            {
               if (pos[0] == i && pos[1] == j)
               {
                  isOnPath = true;
                  break;
               }
            }

            // Choose appropriate symbol
            if (i == start[0] && j == start[1])
            {
               visual.Append("S ");
            }
            else if (i == goal[0] && j == goal[1])
            {
               visual.Append("G ");
            }
            else if (isOnPath)
            {
               visual.Append("* ");
            }
            else if (grid[i][j] == 1)
            {
               visual.Append("█ ");
            }
            else
            {
               visual.Append(". ");
            }
         }
         visual.Append("\n");
      }

      return visual.ToString();
   }

   /**
    * Example usage
    */
   public static void Main(string[] args)
   {
      // 0 = empty space, 1 = wall
      int[][] grid = {
            new int[] { 0, 0, 0, 0, 1 },
            new int[] { 1, 1, 0, 1, 0 },
            new int[] { 0, 0, 0, 0, 0 },
            new int[] { 0, 1, 1, 1, 0 },
            new int[] { 0, 0, 0, 1, 0 }
        };

      int[] start = { 0, 0 };
      int[] goal = { 4, 4 };

      // Find path using A*
      List<int[]> path = AStarPathfinding(grid, start, goal);

      // Print path coordinates
      Console.Write("Path found: ");
      foreach (int[] pos in path)
      {
         Console.Write($"[{pos[0]}, {pos[1]}] ");
      }

      // Print grid visualization
      Console.WriteLine("\n\nGrid visualization:");
      Console.WriteLine(VisualizePath(grid, path, start, goal));
   }
}
