import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
  public static void main(String[] args) {
     // Main method code goes here
  }
  
  /**
   * Tree node with value and children
   */
  public static class Node {
     public int val;
     public Node left;
     public Node right;
     
     public Node(int val) {
        this.val = val;
        this.left = null;
        this.right = null;
     }
  }
  
  /**
   * Serializes and deserializes binary trees
   */
  public static class Codec {
     /**
      * Convert tree to string representation
      */
     public String serialize(Node root) {
        if (root == null) {
           return "null";
        }
        return root.val + "," + serialize(root.left) + "," + 
           serialize(root.right);
     }
     
     /**
      * Convert string back to tree
      */
     public Node deserialize(String data) {
        Queue<String> values = new LinkedList<>(
           Arrays.asList(data.split(",")));
        return deserializeHelper(values);
     }
     
     /**
      * Helper for recursive deserialization
      */
     private Node deserializeHelper(Queue<String> values) {
        String val = values.poll();
        if (val.equals("null")) {
           return null;
        }
        Node node = new Node(Integer.parseInt(val));
        node.left = deserializeHelper(values);
        node.right = deserializeHelper(values);
        return node;
     }
  }
}