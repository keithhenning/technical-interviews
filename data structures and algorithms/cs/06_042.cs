using System;
using System.Collections.Generic;

public class Graph
{
   private Dictionary<string, List<Edge>> graph;

   public Graph()
   {
      graph = new Dictionary<string, List<Edge>>();
   }

   public void AddEdge(string fromNode, string toNode, int weight)
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

   public int DijkstraWithTarget(string start, string target)
   {
      var distances = new Dictionary<string, int>();
      foreach (var node in graph.Keys)
      {
         distances[node] = int.MaxValue;
      }
      distances[start] = 0;

      var pq = new PriorityQueue<KeyValuePair<int, string>, int>();
      pq.Enqueue(new KeyValuePair<int, string>(0, start), 0);

      while (pq.Count > 0)
      {
         var current = pq.Dequeue();
         var currentNode = current.Value;
         var currentDistance = current.Key;

         if (currentNode == target)
         {
            return distances[target];
         }

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
               pq.Enqueue(new KeyValuePair<int, string>(distance, neighbor), distance);
            }
         }
      }

      return int.MaxValue;
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
}
