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
      private List<Node> nodes;

      public void RemoveNode(Node node)
      {
         // First attempt - not very efficient!
         foreach (var currentNode in nodes)
         {
            currentNode.Edges.RemoveAll(edge => edge.ConnectsTo(node));
         }
         nodes.Remove(node);
      }

      public void ViewGraph()
      {
         foreach (Node node in nodes)
         {
            Console.Write(node + ": ");
            foreach (Edge edge in node.Edges)
            {
               Console.Write(edge + " ");
            }
            Console.WriteLine();
         }
      }
   }

   public class Node
   {
      public List<Edge> Edges { get; set; }
   }

   public class Edge
   {
      public bool ConnectsTo(Node node)
      {
         // Implementation goes here
         return false;
      }
   }
}
