using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
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
   }
}
