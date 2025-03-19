using System;
using System.Collections.Generic;

class Graph {
   private int V;
   private List<List<int>> adj;
   
   public Graph(int vertices) {
       V = vertices;
       adj = new List<List<int>>(V);
       for (int i = 0; i < V; i++) {
           adj.Add(new List<int>());
       }
   }
   
   public void AddEdge(int u, int v) {
       adj[u].Add(v);
   }
   
   // Kahn's Algorithm
   public List<int> TopologicalSortKahn() {
       int[] inDegree = new int[V];
       for (int i = 0; i < V; i++) {
           foreach (int neighbor in adj[i]) {
               inDegree[neighbor]++;
           }
       }
       
       Queue<int> queue = new Queue<int>();
       for (int i = 0; i < V; i++) {
           if (inDegree[i] == 0) {
               queue.Enqueue(i);
           }
       }
       
       List<int> result = new List<int>();
       while (queue.Count > 0) {
           int vertex = queue.Dequeue();
           result.Add(vertex);
           
           foreach (int neighbor in adj[vertex]) {
               inDegree[neighbor]--;
               if (inDegree[neighbor] == 0) {
                   queue.Enqueue(neighbor);
               }
           }
       }
       
       return result.Count == V ? result : new List<int>();
   }
   
   // DFS-based Algorithm
   public List<int> TopologicalSortDFS() {
       bool[] visited = new bool[V];
       LinkedList<int> stack = new LinkedList<int>();
       
       for (int i = 0; i < V; i++) {
           if (!visited[i]) {
               DfsUtil(i, visited, stack);
           }
       }
       
       return new List<int>(stack);
   }
   
   private void DfsUtil(int v, bool[] visited, 
                       LinkedList<int> stack) {
       visited[v] = true;
       
       foreach (int neighbor in adj[v]) {
           if (!visited[neighbor]) {
               DfsUtil(neighbor, visited, stack);
           }
       }
       
       stack.AddFirst(v);
   }
}