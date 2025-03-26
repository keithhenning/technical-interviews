using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   public class DirectedGraph
   {
      private Dictionary<object, List<object>> graph;

      public DirectedGraph()
      {
         this.graph = new Dictionary<object, List<object>>();
      }

      public void AddRelationship(object fromNode, object toNode)
      {
         if (!this.graph.ContainsKey(fromNode))
         {
            this.graph[fromNode] = new List<object>();
         }
         this.graph[fromNode].Add(toNode);
      }
   }
}
