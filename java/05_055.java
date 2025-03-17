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
    
    public class BSTIterator {
        private Stack<Node> stack;
        
        public BSTIterator(Node root) {
            this.stack = new Stack<>();
            this.leftmostInorder(root);
        }
        
        private void leftmostInorder(Node root) {
            while (root != null) {
                this.stack.push(root);
                root = root.left;
            }
        }
        
        public int next() {
            Node topmostNode = this.stack.pop();
            if (topmostNode.right != null) {
                this.leftmostInorder(topmostNode.right);
            }
            return topmostNode.key;
        }
        
        public boolean hasNext() {
            return !this.stack.isEmpty();
        }
    }
}