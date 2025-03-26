using System;
using System.Collections.Generic;

public class KeyCollectionSequence
{
   public static int MinimumStepsToCollectKeys(
      string[] maze)
   {
      int rows = maze.Length;
      int cols = maze[0].Length;

      int startRow = 0, startCol = 0;
      var keys = new List<char>();

      for (int r = 0; r < rows; r++)
      {
         for (int c = 0; c < cols; c++)
         {
            char cell = maze[r][c];
            if (cell == 'S')
            {
               startRow = r;
               startCol = c;
            }
            else if ('a' <= cell && cell <= 'z')
            {
               keys.Add(cell);
            }
         }
      }

      keys.Sort();

      int[][] directions =
      {
         new[] { -1, 0 },
         new[] { 0, 1 },
         new[] { 1, 0 },
         new[] { 0, -1 }
      };

      int currRow = startRow, currCol = startCol;
      int totalSteps = 0;
      var collectedKeys = new HashSet<char>();

      foreach (var key in keys)
      {
         var queue = new Queue<int[]>();
         queue.Enqueue(new[] { currRow, currCol, 0 });
         var visited = new HashSet<string>
         {
            currRow + "," + currCol
         };
         bool found = false;

         while (queue.Count > 0 && !found)
         {
            var curr = queue.Dequeue();
            int r = curr[0], c = curr[1], steps = curr[2];

            if (maze[r][c] == key)
            {
               totalSteps += steps;
               currRow = r;
               currCol = c;
               collectedKeys.Add(key);
               found = true;
               break;
            }

            foreach (var dir in directions)
            {
               int nr = r + dir[0], nc = c + dir[1];

               if (0 <= nr && nr < rows &&
                  0 <= nc && nc < cols &&
                  maze[nr][nc] != '#' &&
                  !visited.Contains(nr + "," + nc))
               {
                  char cell = maze[nr][nc];
                  if ('A' <= cell && cell <= 'Z')
                  {
                     char keyNeeded = char.ToLower(cell);
                     if (!collectedKeys.Contains(keyNeeded))
                     {
                        continue;
                     }
                  }

                  queue.Enqueue(new[] { nr, nc, steps + 1 });
                  visited.Add(nr + "," + nc);
               }
            }
         }

         if (!found)
         {
            return -1;
         }
      }

      return totalSteps;
   }
}