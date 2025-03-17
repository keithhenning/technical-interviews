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
    
    public boolean isBalanced(Node root) {
        return checkHeight(root) != -1;
    }
    
    private int checkHeight(Node node) {
        if (node == null) {
            return 0;
        }
        
        int left = checkHeight(node.left);
        if (left == -1) {
            return -1;
        }
            
        int right = checkHeight(node.right);
        if (right == -1) {
            return -1;
        }
            
        if (Math.abs(left - right) > 1) {
            return -1;
        }
            
        return 1 + Math.max(left, right);
    }
}