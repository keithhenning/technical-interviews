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
    }
}