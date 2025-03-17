import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public class BookRecommendationGraph {
        private Map<String, Map<String, Integer>> graph;
        
        public BookRecommendationGraph() {
            this.graph = new HashMap<>();
        }
        
        public void addBookRelationship(String book1, 
                                        String book2, 
                                        int weight) {
            if (!this.graph.containsKey(book1)) {
                this.graph.put(book1, new HashMap<>());
            }
            if (!this.graph.containsKey(book2)) {
                this.graph.put(book2, new HashMap<>());
            }
                
            this.graph.get(book1).put(book2, weight);
            this.graph.get(book2).put(book1, weight);
        }
        
        public List<Map.Entry<String, Integer>> 
        getRecommendations(String book, int limit) {
            if (!this.graph.containsKey(book)) {
                return new ArrayList<>();
            }
                
            List<Map.Entry<String, Integer>> 
                sortedRecommendations = new ArrayList<>(
                    this.graph.get(book).entrySet());
            sortedRecommendations.sort((a, b) -> 
                b.getValue().compareTo(a.getValue()));
            
            return sortedRecommendations.stream()
                     .limit(limit)
                     .collect(Collectors.toList());
        }
    }
}