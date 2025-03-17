import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public class Graph {
        private Map<Object, List<Object>> graph;
        
        public Graph() {
            this.graph = new HashMap<>();
        }
        
        public void bfs(Object start) {
            // Keep track of who we've seen
            Set<Object> visited = new HashSet<>();
            // People to visit next
            Queue<Object> queue = new LinkedList<>();     
            // Add start node to queue
            queue.add(start); 
            // Mark start as seen
            visited.add(start);
            
            while (!queue.isEmpty()) {
                // Get next person to visit
                Object vertex = queue.poll();              
                // Say hello!
                System.out.print(vertex + " ");            
                
                // Check all their friends
                for (Object neighbor : this.graph.get(vertex)) {  
                    // If we haven't met them yet
                    if (!visited.contains(neighbor)) {            
                        // Mark them as seen
                        visited.add(neighbor);                    
                        // Add to people to visit
                        queue.add(neighbor);                      
                    }
                }
            }
        }
    }
}