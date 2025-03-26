using System;
using System.Collections.Generic;
using System.Linq;

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
         this.graph = new Dictionary<string, Dictionary<string, int>>();
      }

      public void AddBookRelationship(string book1, string book2, int weight)
      {
         if (!this.graph.ContainsKey(book1))
         {
            this.graph[book1] = new Dictionary<string, int>();
         }
         if (!this.graph.ContainsKey(book2))
         {
            this.graph[book2] = new Dictionary<string, int>();
         }

         this.graph[book1][book2] = weight;
         this.graph[book2][book1] = weight;
      }

      public List<KeyValuePair<string, int>> GetRecommendations(string book, int limit)
      {
         if (!this.graph.ContainsKey(book))
         {
            return new List<KeyValuePair<string, int>>();
         }

         List<KeyValuePair<string, int>> sortedRecommendations = this.graph[book].ToList();
         sortedRecommendations.Sort((a, b) => b.Value.CompareTo(a.Value));

         return sortedRecommendations.Take(limit).ToList();
      }
   }
}
