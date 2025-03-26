using System;
using System.Collections.Generic;

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
         AddVertex(v1);
      }
      if (!this.graph.ContainsKey(v2))
      {
         AddVertex(v2);
      }
      this.graph[v1].Add(v2);
   }

   public IEnumerable<object> GetAllVertices()
   {
      return graph.Keys;
   }

   public bool HasEdge(object v1, object v2)
   {
      return graph.ContainsKey(v1) && graph[v1].Contains(v2);
   }
}
