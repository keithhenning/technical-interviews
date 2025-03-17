import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
   public static void main(String[] args) {
      // Main method code goes here
   }
   
   /**
    * Graph for book recommendations with weights
    */
   public static class BookRecommendationGraph {
      // Map of books to their related books with weights
      private Map<String, Map<String, Integer>> graph;
      
      public BookRecommendationGraph() {
         this.graph = new HashMap<>();
      }
      
      /**
       * Add weighted relationship between two books
       */
      public void addBookRelationship(String book1, 
            String book2, int weight) {
         // Create entries if books don't exist
         if (!this.graph.containsKey(book1)) {
            this.graph.put(book1, new HashMap<>());
         }
         if (!this.graph.containsKey(book2)) {
            this.graph.put(book2, new HashMap<>());
         }
            
         // Add bidirectional relationship
         this.graph.get(book1).put(book2, weight);
         this.graph.get(book2).put(book1, weight);
      }
      
      /**
       * Get top book recommendations by weight
       */
      public List<Map.Entry<String, Integer>> 
            getRecommendations(String book, int limit) {
         // Return empty list if book not found
         if (!this.graph.containsKey(book)) {
            return new ArrayList<>();
         }
            
         // Sort recommendations by weight descending
         List<Map.Entry<String, Integer>> sortedRecs = 
            new ArrayList<>(this.graph.get(book).entrySet());
         sortedRecs.sort((a, b) -> 
            b.getValue().compareTo(a.getValue()));
         
         // Return limited number of top recommendations
         return sortedRecs.stream()
                  .limit(limit)
                  .collect(Collectors.toList());
      }
   }
}