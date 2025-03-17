import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Create a social network
        Graph socialGraph = new Graph();

        // Add some connections
        socialGraph.addEdge("Alice", "Bob");
        socialGraph.addEdge("Alice", "Charlie");
        socialGraph.addEdge("Bob", "David");

        // Explore connections starting from Alice
        socialGraph.bfs("Alice"); // Output: Alice Bob Charlie David
    }
    
    public static class Graph {
        private Map<Object, List<Object>> graph;
        
        public Graph() {
            this.graph = new HashMap<>();
        }
        
        public void addVertex(Object vertex) {
            if (!this.graph.containsKey(vertex)) {
                this.graph.put(vertex, new ArrayList<>());
            }
        }
        
        public void addEdge(Object v1, Object v2) {
            if (!this.graph.containsKey(v1)) {
                this.addVertex(v1);
            }
            if (!this.graph.containsKey(v2)) {
                this.addVertex(v2);
            }
            this.graph.get(v1).add(v2);
        }
        
        public void removeNode(Object node) {
            if (!this.graph.containsKey(node)) {
                return;
            }
            
            for (Object friend : this.graph.get(node)) {
                this.graph.get(friend).remove(node);
            }
            
            this.graph.remove(node);
        }
        
        public void bfs(Object start) {
            Set<Object> visited = new HashSet<>();
            Queue<Object> queue = new LinkedList<>();
            queue.add(start);
            visited.add(start);
            
            while (!queue.isEmpty()) {
                Object node = queue.poll();
                System.out.print(node + " ");
                
                for (Object friend : this.graph.get(node)) {
                    if (!visited.contains(friend)) {
                        visited.add(friend);
                        queue.add(friend);
                    }
                }
            }
        }
    }
}