import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public class BinaryTree {
        public int getHeight(Node node) {
            if (node == null) {
                return 0;
            }
            return 1 + Math.max(this.getHeight(node.left), 
                              this.getHeight(node.right));
        }
    }
}