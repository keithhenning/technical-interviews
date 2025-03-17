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
    }
}