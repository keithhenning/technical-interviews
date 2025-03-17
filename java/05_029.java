import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public class DirectedGraph {
        private Map<Object, List<Object>> graph;
        
        public DirectedGraph() {
            this.graph = new HashMap<>();
        }
        
        public void addRelationship(Object fromNode, Object toNode) {
            if (!this.graph.containsKey(fromNode)) {
                this.graph.put(fromNode, new ArrayList<>());
            }
            this.graph.get(fromNode).add(toNode);
        }
    }
}