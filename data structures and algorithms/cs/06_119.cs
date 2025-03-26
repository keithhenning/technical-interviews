using System;
using System.Collections.Generic;

public class EdmondsKarp
{
   private int vertices;
   private int[,] capacity;
   private int[,] flow;
   private List<int>[] graph;
   /*
   * Initialize a flow network with given number of vertices
   */

   /*
   * Initialize a flow network with given number of vertices
   */
   public EdmondsKarp(int vertices)
   {
      this.vertices = vertices;
      capacity = new int[vertices, vertices];
      flow = new int[vertices, vertices];
      graph = new List<int>[vertices];

      for (int i = 0; i < vertices; i++)
      {
         graph[i] = new List<int>();
      }
   }

   /**
    * Add edge with capacity to the flow network
    */
   public void AddEdge(int u, int v, int cap)
   {
      // Add forward edge if not present
      if (!graph[u].Contains(v))
      {
         graph[u].Add(v);
      }
      // Add backward edge for residual graph
      if (!graph[v].Contains(u))
      {
         graph[v].Add(u);
      }
      // Set capacity
      capacity[u, v] = cap;
   }

   /**
    * Find augmenting path using BFS
    */
   private bool Bfs(int source, int sink, int[] parent)
   {
      bool[] visited = new bool[vertices];
      Array.Fill(visited, false);
      Array.Fill(parent, -1);

      Queue<int> queue = new Queue<int>();
      queue.Enqueue(source);
      visited[source] = true;
      parent[source] = -1;

      while (queue.Count > 0)
      {
         int u = queue.Dequeue();

         foreach (int v in graph[u])
         {
            // If not visited and has residual capacity
            if (!visited[v] &&
                capacity[u, v] > flow[u, v])
            {
               queue.Enqueue(v);
               parent[v] = u;
               visited[v] = true;
            }
         }
      }

      // Return true if sink was reached
      return visited[sink];
   }

   /**
    * Compute maximum flow using Edmonds-Karp algorithm
    */
   public int FindMaxFlow(int source, int sink)
   {
      int[] parent = new int[vertices];
      int maxFlow = 0;

      // Augment flow while there is a path
      while (Bfs(source, sink, parent))
      {
         // Find minimum residual capacity along path
         int pathFlow = int.MaxValue;
         for (int v = sink; v != source; v = parent[v])
         {
            int u = parent[v];
            pathFlow = Math.Min(
               pathFlow,
               capacity[u, v] - flow[u, v]
            );
         }

         // Update flow along the path
         for (int v = sink; v != source; v = parent[v])
         {
            int u = parent[v];
            flow[u, v] += pathFlow;
            flow[v, u] -= pathFlow;  // For residual graph
         }

         // Add path flow to total flow
         maxFlow += pathFlow;
      }

      return maxFlow;
   }

   /**
    * Print flow values for all edges
    */
   public void PrintFlow()
   {
      Console.WriteLine("Edge \tFlow/Capacity");
      for (int i = 0; i < vertices; i++)
      {
         foreach (int j in graph[i])
         {
            if (capacity[i, j] > 0)
            {  // Print forward edges
               Console.WriteLine(i + " -> " + j + " \t" + flow[i, j] + "/" + capacity[i, j]);
            }
         }
      }
   }

   /**
    * Main method demonstrating algorithm
    */
   public static void Main(string[] args)
   {
      // Create a flow network with 6 vertices
      EdmondsKarp graph = new EdmondsKarp(6);

      // Add edges with capacities
      graph.AddEdge(0, 1, 16);
      graph.AddEdge(0, 2, 13);
      graph.AddEdge(1, 2, 10);
      graph.AddEdge(1, 3, 12);
      graph.AddEdge(2, 1, 4);
      graph.AddEdge(2, 4, 14);
      graph.AddEdge(3, 2, 9);
      graph.AddEdge(3, 5, 20);
      graph.AddEdge(4, 3, 7);
      graph.AddEdge(4, 5, 4);

      int source = 0;
      int sink = 5;

      // Calculate maximum flow
      int maxFlow = graph.FindMaxFlow(source, sink);

      Console.WriteLine("Maximum flow from " + source
                        + " to " + sink + ": " + maxFlow);
      graph.PrintFlow();
   }
}