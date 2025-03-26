using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   public class UndirectedGraph
   {
      private Dictionary<object, List<object>> graph;

      public UndirectedGraph()
      {
         this.graph = new Dictionary<object, List<object>>();
      }

      public void AddRelationship(object node1, object node2)
      {
         // Ensure both nodes exist in the graph
         if (!this.graph.ContainsKey(node1))
         {
            this.graph[node1] = new List<object>();
         }
         if (!this.graph.ContainsKey(node2))
         {
            this.graph[node2] = new List<object>();
         }

         // Add bidirectional relationship
         this.graph[node1].Add(node2);
         this.graph[node2].Add(node1);
      }
   }
}
