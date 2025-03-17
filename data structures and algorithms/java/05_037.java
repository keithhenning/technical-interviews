import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
  public static void main(String[] args) {
     // Main method code goes here
  }
  
  /**
   * Graph representation using adjacency list
   */
  public static class Graph {
     // Adjacency list representation
     private Map<Object, List<Object>> adjList;
     
     public Graph() {
        this.adjList = new HashMap<>();
     }
     
     /**
      * Removes a node and all its connections
      */
     public void removeNode(Object node) {
        // Return if node doesn't exist
        if (!this.adjList.containsKey(node)) {
           return;
        }
           
        // Remove connections to this node from neighbors
        for (Object friend : this.adjList.get(node)) {
           this.adjList.get(friend).remove(node);
        }
           
        // Remove the node itself
        this.adjList.remove(node);
     }
  }
}