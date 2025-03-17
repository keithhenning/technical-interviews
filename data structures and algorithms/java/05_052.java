import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public class Node {
        public int key;
        public Node left;
        public Node right;
        
        public Node(int key) {
            this.key = key;
        }
    }
    
    public int kthSmallest(Node root, int k) {
        // Perform inorder traversal and return the kth element
        List<Integer> result = new ArrayList<>();
        
        inorder(root, result, k);
        
        return k <= result.size() ? result.get(k-1) : -1;
    }
    
    private void inorder(Node node, List<Integer> result, int k) {
        if (node == null || result.size() >= k) {
            return;
        }
        inorder(node.left, result, k);
        result.add(node.key);
        inorder(node.right, result, k);
    }
}