using System;
using System.Collections.Generic;

public class Graph {
   private Dictionary<string, List<Edge>> graph;

   public Graph() {
      graph = new Dictionary<string, List<Edge>>();
   }

   public void AddEdge(
      string fromNode, 
      string toNode, 
      int weight
   ) {
      if (!graph.ContainsKey(fromNode)) {
         graph[fromNode] = new List<Edge>();
      }
      graph[fromNode].Add(new Edge(toNode, weight));

      if (!graph.ContainsKey(toNode)) {
         graph[toNode] = new List<Edge>();
      }
   }

   public static List<string> FindFastestDeliveryRoute(
      string restaurant,
      string customer,
      Dictionary<string[], TrafficData> trafficData
   ) {
      var graph = new Graph();

      foreach (var entry in trafficData) {
         var road = entry.Key;
         var traffic = entry.Value;
         var time = CalculateTravelTime(traffic);
         graph.AddEdge(road[0], road[1], time);
      }

      var result = graph.Dijkstra(restaurant);
      var paths = result.Value;

      return paths[customer];
   }

   private static int CalculateTravelTime(
      TrafficData traffic
   ) {
      return 0;
   }

   private class Edge {
      public string Destination { get; }
      public int Weight { get; }

      public Edge(string destination, int weight) {
         Destination = destination;
         Weight = weight;
      }
   }

   public KeyValuePair<
      Dictionary<string, int>,
      Dictionary<string, List<string>>
   > Dijkstra(string start) {
      var distances = new Dictionary<string, int>();
      foreach (var node in graph.Keys) {
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

      while (pq.Count > 0) {
         var current = pq.Dequeue();
         var currentNode = current.Value;
         var currentDistance = current.Key;

         if (currentDistance > distances[currentNode]) {
            continue;
         }

         foreach (var edge in graph[currentNode]) {
            var neighbor = edge.Destination;
            var weight = edge.Weight;
            var distance = currentDistance + weight;

            if (distance < distances[neighbor]) {
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
}

public class TrafficData {
}
