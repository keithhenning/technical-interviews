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
      int weight)
   {
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
      Dictionary<string, List<string>>>
   Dijkstra(string start)
   {
      var distances = new Dictionary<string, int>();
      foreach (var node in graph.Keys)
      {
         distances[node] = int.MaxValue;
      }
      distances[start] = 0;

      var pq = new PriorityQueue<
         KeyValuePair<int, string>,
         int>();
      pq.Enqueue(
         new KeyValuePair<int, string>(0, start),
         0);

      var paths = new Dictionary<string, List<string>>();
      var startPath = new List<string> { start };
      paths[start] = startPath;

      while (pq.Count > 0)
      {
         var current = pq.Dequeue();
         var currentNode = current.Value;
         var currentDistance = current.Key;

         if (currentDistance > distances[currentNode])
         {
            continue;
         }

         foreach (var edge in graph[currentNode])
         {
            var neighbor = edge.Destination;
            var weight = edge.Weight;
            var distance = currentDistance + weight;

            if (distance < distances[neighbor])
            {
               distances[neighbor] = distance;
               var newPath = new List<string>(
                  paths[currentNode])
               {
                  neighbor
               };
               paths[neighbor] = newPath;
               pq.Enqueue(
                  new KeyValuePair<int, string>(
                     distance,
                     neighbor),
                  distance);
            }
         }
      }

      return new KeyValuePair<
         Dictionary<string, int>,
         Dictionary<string, List<string>>>(
            distances,
            paths);
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

   public static void TestDijkstra()
   {
      // Test Case 1: Simple path
      var g1 = new Graph();
      g1.AddEdge("Dallas", "Chicago", 920);
      g1.AddEdge("Dallas", "Memphis", 410);
      g1.AddEdge("Chicago", "Boston", 850);
      g1.AddEdge("Memphis", "Boston", 1200);
      g1.AddEdge("Memphis", "Chicago", 480);

      var result1 = g1.Dijkstra("Dallas");
      var distances1 = result1.Key;
      var paths1 = result1.Value;

      // Verify correct distances
      if (distances1["Dallas"] != 0)
         throw new Exception("Test case 1 distances failed");
      if (distances1["Chicago"] != 890)
         throw new Exception("Test case 1 distances failed");
      if (distances1["Memphis"] != 410)
         throw new Exception("Test case 1 distances failed");
      if (distances1["Boston"] != 1740)
         throw new Exception("Test case 1 distances failed");

      // Verify correct paths
      if (!paths1["Dallas"].SequenceEqual(new List<string> { "Dallas" }))
         throw new Exception("Test case 1 paths failed");
      if (!paths1["Chicago"].SequenceEqual(new List<string> { "Dallas", "Memphis", "Chicago" }))
         throw new Exception("Test case 1 paths failed");
      if (!paths1["Memphis"].SequenceEqual(new List<string> { "Dallas", "Memphis" }))
         throw new Exception("Test case 1 paths failed");
      if (!paths1["Boston"].SequenceEqual(new List<string> { "Dallas", "Memphis", "Chicago", "Boston" }))
         throw new Exception("Test case 1 paths failed");
      Console.WriteLine("Test case 1 passed!");

      // Test Case 2: Disconnected graph
      var g2 = new Graph();
      g2.AddEdge("Dallas", "Chicago", 920);
      g2.AddEdge("Atlanta", "Miami", 610);

      var result2 = g2.Dijkstra("Dallas");
      var distances2 = result2.Key;
      var paths2 = result2.Value;

      // Verify reachable and unreachable nodes
      if (distances2["Chicago"] != 920)
         throw new Exception("Test case 2 reachable distance failed");
      if (distances2["Atlanta"] != int.MaxValue)
         throw new Exception("Test case 2 unreachable distance failed");
      if (distances2["Miami"] != int.MaxValue)
         throw new Exception("Test case 2 unreachable distance failed");
      if (paths2.ContainsKey("Atlanta") || paths2.ContainsKey("Miami"))
         throw new Exception("Test case 2 unreachable paths failed");
      Console.WriteLine("Test case 2 passed!");

      // Test Case 3: Cyclic graph
      var g3 = new Graph();
      g3.AddEdge("Dallas", "Chicago", 920);
      g3.AddEdge("Chicago", "Atlanta", 590);
      g3.AddEdge("Atlanta", "Dallas", 780);
      g3.AddEdge("Chicago", "Boston", 850);

      var result3 = g3.Dijkstra("Dallas");
      var distances3 = result3.Key;
      var paths3 = result3.Value;

      // Verify cyclic graph distances and paths
      if (distances3["Dallas"] != 0)
         throw new Exception("Test case 3 distances failed");
      if (distances3["Chicago"] != 920)
         throw new Exception("Test case 3 distances failed");
      if (distances3["Atlanta"] != 1510)
         throw new Exception("Test case 3 distances failed");
      if (distances3["Boston"] != 1770)
         throw new Exception("Test case 3 distances failed");
      if (!paths3["Boston"].SequenceEqual(new List<string> { "Dallas", "Chicago", "Boston" }))
         throw new Exception("Test case 3 paths failed");
      Console.WriteLine("Test case 3 passed!");

      // Test Case 4: Multiple paths to destination
      var g4 = new Graph();
      g4.AddEdge("Dallas", "Chicago", 920);
      g4.AddEdge("Dallas", "Memphis", 410);
      g4.AddEdge("Chicago", "Boston", 850);
      g4.AddEdge("Memphis", "Boston", 1400);
      g4.AddEdge("Dallas", "Boston", 1800);

      var result4 = g4.Dijkstra("Dallas");
      var distances4 = result4.Key;
      var paths4 = result4.Value;

      // Verify optimal path is found
      if (distances4["Boston"] != 1770)
         throw new Exception("Test case 4 distance failed");
      if (!paths4["Boston"].SequenceEqual(new List<string> { "Dallas", "Chicago", "Boston" }))
         throw new Exception("Test case 4 path failed");
      Console.WriteLine("Test case 4 passed!");

      // Test Case 5: Large weights
      var g5 = new Graph();
      g5.AddEdge("Dallas", "Chicago", 1000000);
      g5.AddEdge("Chicago", "Boston", 2000000);

      var result5 = g5.Dijkstra("Dallas");
      var distances5 = result5.Key;

      // Verify large weight handling
      if (distances5["Boston"] != 3000000)
         throw new Exception("Test case 5 large weights failed");
      Console.WriteLine("Test case 5 passed!");

      Console.WriteLine("\nAll test cases passed successfully!");
      Console.WriteLine("Your implementation handles:");
      Console.WriteLine("Basic shortest path finding");
      Console.WriteLine("Disconnected graphs");
      Console.WriteLine("Cyclic graphs");
      Console.WriteLine("Multiple paths to same destination");
      Console.WriteLine("Large weight values");
   }
}
