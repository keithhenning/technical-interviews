using System;
using System.Collections.Generic;

public class FloydWarshall
{
   private static readonly int INF = int.MaxValue / 2;

   public static void Main(string[] args)
   {
      int[][] graph = {
            new int[] {0, 5, INF, 10},
            new int[] {INF, 0, 3, INF},
            new int[] {INF, INF, 0, 1},
            new int[] {INF, INF, INF, 0}
        };

      var result = FloydWarshallAlgorithm(graph);

      Console.WriteLine("Shortest distances:");
      foreach (var row in result.Distances)
      {
         Console.WriteLine(string.Join(", ", row));
      }

      var path = GetPath(0, 3, result.NextVertex);
      if (path.Count > 0)
      {
         Console.WriteLine("Path from 0 to 3: " +
            string.Join(" -> ", path));
      }
   }

   public class FloydWarshallResult
   {
      public int[][] Distances { get; set; }
      public int?[][] NextVertex { get; set; }
   }

   public static FloydWarshallResult
      FloydWarshallAlgorithm(int[][] graph)
   {
      int n = graph.Length;
      int[][] dist = new int[n][];
      int?[][] next = new int?[n][];

      for (int i = 0; i < n; i++)
      {
         dist[i] = new int[n];
         next[i] = new int?[n];
         for (int j = 0; j < n; j++)
         {
            dist[i][j] = graph[i][j];
            if (graph[i][j] != INF && i != j)
            {
               next[i][j] = j;
            }
         }
      }

      for (int k = 0; k < n; k++)
      {
         for (int i = 0; i < n; i++)
         {
            for (int j = 0; j < n; j++)
            {
               if (dist[i][k] + dist[k][j] < dist[i][j])
               {
                  dist[i][j] = dist[i][k] + dist[k][j];
                  next[i][j] = next[i][k];
               }
            }
         }
      }

      return new FloydWarshallResult
      {
         Distances = dist,
         NextVertex = next
      };
   }

   public static List<int> GetPath(int start,
      int end, int?[][] next)
   {
      if (next[start][end] == null)
      {
         return new List<int>();
      }

      List<int> path = new List<int> { start };
      while (start != end)
      {
         start = next[start][end].Value;
         path.Add(start);
      }

      return path;
   }
}
