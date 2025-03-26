using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Create a social network
      Graph socialGraph = new Graph();

      // Add some connections
      socialGraph.AddEdge("Alice", "Bob");
      socialGraph.AddEdge("Alice", "Charlie");
      socialGraph.AddEdge("Bob", "David");

      // Explore connections starting from Alice
      socialGraph.Bfs("Alice"); // Output: Alice Bob Charlie David
   }

   public class Graph
   {
      private Dictionary<object, List<object>> graph;

      public Graph()
      {
         this.graph = new Dictionary<object, List<object>>();
      }

      public void AddVertex(object vertex)
      {
         if (!this.graph.ContainsKey(vertex))
         {
            this.graph[vertex] = new List<object>();
         }
      }

      public void AddEdge(object v1, object v2)
      {
         if (!this.graph.ContainsKey(v1))
         {
            this.AddVertex(v1);
         }
         if (!this.graph.ContainsKey(v2))
         {
            this.AddVertex(v2);
         }
         this.graph[v1].Add(v2);
      }

      public void RemoveNode(object node)
      {
         if (!this.graph.ContainsKey(node))
         {
            return;
         }

         foreach (var friend in this.graph[node])
         {
            this.graph[friend].Remove(node);
         }

         this.graph.Remove(node);
      }

      public void Bfs(object start)
      {
         var visited = new HashSet<object>();
         var queue = new Queue<object>();
         queue.Enqueue(start);
         visited.Add(start);

         while (queue.Count > 0)
         {
            var node = queue.Dequeue();
            Console.Write(node + " ");

            foreach (var friend in this.graph[node])
            {
               if (!visited.Contains(friend))
               {
                  visited.Add(friend);
                  queue.Enqueue(friend);
               }
            }
         }
      }
   }
}