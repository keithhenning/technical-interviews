import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public class Graph {
        private List<Node> nodes;
        
        public void removeNode(Node node) {
            // First attempt - not very efficient!
            for (Node currentNode : this.nodes) {
                for (Edge edge : currentNode.edges) {
                    if (edge.connectsTo(node)) {
                        currentNode.edges.remove(edge);
                    }
                }
            }
            this.nodes.remove(node);
        }
    }
}