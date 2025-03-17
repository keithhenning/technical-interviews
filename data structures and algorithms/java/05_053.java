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
    
    public Node lowestCommonAncestor(Node root, Node p, Node q) {
        if (p.key < root.key && q.key < root.key) {
            return lowestCommonAncestor(root.left, p, q);
        } else if (p.key > root.key && q.key > root.key) {
            return lowestCommonAncestor(root.right, p, q);
        } else {
            return root;
        }
    }
}