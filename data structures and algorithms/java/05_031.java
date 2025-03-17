import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public class UndirectedGraph {
        private Map<Object, List<Object>> graph;
        
        public UndirectedGraph() {
            this.graph = new HashMap<>();
        }
        
        public void addRelationship(Object node1, Object node2) {
            // Ensure both nodes exist in the graph
            if (!this.graph.containsKey(node1)) {
                this.graph.put(node1, new ArrayList<>());
            }
            if (!this.graph.containsKey(node2)) {
                this.graph.put(node2, new ArrayList<>());
            }
                
            // Add bidirectional relationship
            this.graph.get(node1).add(node2);
            this.graph.get(node2).add(node1);
        }
    }
}