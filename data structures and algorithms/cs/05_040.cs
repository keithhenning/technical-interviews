using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   public class BookRecommendationGraph
   {
      private Dictionary<string, Dictionary<string, int>> graph;

      public BookRecommendationGraph()
      {
         graph = new Dictionary<string, Dictionary<string, int>>();
      }

      public void AddBookRelationship(
         string book1, string book2, int weight)
      {
         if (!graph.ContainsKey(book1))
         {
            graph[book1] = new Dictionary<string, int>();
         }
         graph[book1][book2] = weight;
      }

      public List<KeyValuePair<string, int>> GetRecommendations(
         string book, int limit)
      {
         if (!graph.ContainsKey(book))
         {
            return new List<KeyValuePair<string, int>>();
         }

         var recommendations = new List<KeyValuePair<string, int>>(
            graph[book]);
         recommendations.Sort((a, b) =>
            b.Value.CompareTo(a.Value));
         return recommendations.GetRange(0,
            Math.Min(limit, recommendations.Count));
      }
   }
}
