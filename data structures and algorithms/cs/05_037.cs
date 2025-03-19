using System;
using System.Collections.Generic;

public class MainClass {
  public static void Main(string[] args) {
     // Main method code goes here
  }
  
  /**
   * Graph representation using adjacency list
   */
  public static class Graph {
     // Adjacency list representation
     private Dictionary<object, List<object>> adjList;
     
     public Graph() {
        this.adjList = new Dictionary<object, List<object>>();
     }
     
     /**
      * Removes a node and all its connections
      */
     public void RemoveNode(object node) {
        // Return if node doesn't exist
        if (!this.adjList.ContainsKey(node)) {
           return;
        }
           
        // Remove connections to this node from neighbors
        foreach (object friend in this.adjList[node]) {
           this.adjList[friend].Remove(node);
        }
           
        // Remove the node itself
        this.adjList.Remove(node);
     }
  }
}
