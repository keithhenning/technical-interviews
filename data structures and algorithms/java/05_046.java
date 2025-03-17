import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public class Node {
        public int val;
        public Node left;
        public Node right;
        
        public Node(int val) {
            this.val = val;
        }
    }
    
    public List<Integer> inorderTraversal(Node root) {
        if (root == null) {
            return new ArrayList<>();
        }
        
        List<Integer> result = new ArrayList<>();
        // Left, Root, Right
        result.addAll(inorderTraversal(root.left));
        result.add(root.val);
        result.addAll(inorderTraversal(root.right));
        return result;
    }
}