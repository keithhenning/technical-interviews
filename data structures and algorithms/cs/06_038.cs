using System;
using System.Collections.Generic;

public class Graph
{
   private Dictionary<string, List<Edge>> graph;

   public Graph()
   {
      graph = new Dictionary<string, List<Edge>>();
   }

   public void AddEdge(
     string fromNode,
     string toNode,
     int weight
   )
   {
      if (weight < 0)
      {
         throw new ArgumentException(
           "Negative weights not allowed in Dijkstra's"
         );
      }

      if (!graph.ContainsKey(fromNode))
      {
         graph[fromNode] = new List<Edge>();
      }
      graph[fromNode].Add(new Edge(toNode, weight));

      if (!graph.ContainsKey(toNode))
      {
         graph[toNode] = new List<Edge>();
      }
   }

   public KeyValuePair<
     Dictionary<string, int>,
     Dictionary<string, List<string>>
   > Dijkstra(string start)
   {
      if (!graph.ContainsKey(start))
      {
         throw new ArgumentException(
           $"Start node '{start}' not in graph"
         );
      }

      var distances = new Dictionary<string, int>();
      foreach (var node in graph.Keys)
      {
         distances[node] = int.MaxValue;
      }
      distances[start] = 0;

      var pq = new PriorityQueue<
        KeyValuePair<int, string>,
        int
      >();
      pq.Enqueue(
        new KeyValuePair<int, string>(0, start),
        0
      );

      var paths = new Dictionary<string, List<string>>();
      var startPath = new List<string> { start };
      paths[start] = startPath;

      while (pq.Count > 0)
      {
         var current = pq.Dequeue();
         var currentNode = current.Value;
         var currentDist = current.Key;

         if (currentDist > distances[currentNode])
         {
            continue;
         }

         foreach (var edge in graph[currentNode])
         {
            var neighbor = edge.Destination;
            var weight = edge.Weight;
            var distance = currentDist + weight;

            if (distance < distances[neighbor])
            {
               distances[neighbor] = distance;
               var newPath = new List<string>(
                 paths[currentNode]
               ) { neighbor };
               paths[neighbor] = newPath;
               pq.Enqueue(
                 new KeyValuePair<int, string>(
                   distance,
                   neighbor
                 ),
                 distance
               );
            }
         }
      }

      return new KeyValuePair<
        Dictionary<string, int>,
        Dictionary<string, List<string>>
      >(distances, paths);
   }

   private class Edge
   {
      public string Destination { get; }
      public int Weight { get; }

      public Edge(string destination, int weight)
      {
         Destination = destination;
         Weight = weight;
      }
   }

   public static void Main(string[] args)
   {
      var g = new Graph();
      g.AddEdge("Dallas", "Chicago", 920);
      g.AddEdge("Dallas", "Memphis", 410);
      g.AddEdge("Chicago", "Boston", 850);
      g.AddEdge("Memphis", "Atlanta", 335);
      g.AddEdge("Memphis", "Chicago", 480);
      g.AddEdge("Atlanta", "Miami", 610);
      g.AddEdge("Atlanta", "Boston", 1070);
      g.AddEdge("Boston", "Miami", 1450);

      var startNode = "Dallas";
      var result = g.Dijkstra(startNode);
      var distances = result.Key;
      var paths = result.Value;

      Console.WriteLine(
        $"Shortest distances from {startNode}:"
      );
      foreach (var entry in distances)
      {
         Console.WriteLine(
           $"  To {entry.Key}: {entry.Value} miles"
         );
      }

      Console.WriteLine("\nShortest paths:");
      foreach (var entry in paths)
      {
         var node = entry.Key;
         var path = entry.Value;

         if (node != startNode)
         {
            var pathStr = string.Join(" -> ", path);
            Console.WriteLine(
              $"  To {node}: {pathStr} " +
              $"(distance: {distances[node]} miles)"
            );
         }
      }
   }
}
