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
    
    public boolean isValidBST(Node root, long minVal, long maxVal) {
        if (root == null) {
            return true;
        }
        
        if (root.key <= minVal || root.key >= maxVal) {
            return false;
        }
        
        return (isValidBST(root.left, minVal, root.key) && 
                isValidBST(root.right, root.key, maxVal));
    }
    
    public boolean isValidBST(Node root) {
        return isValidBST(root, Long.MIN_VALUE, Long.MAX_VALUE);
    }
}