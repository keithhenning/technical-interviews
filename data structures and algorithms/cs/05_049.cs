using System;

public class MainClass {
    public static void Main(string[] args) {
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
    
    public bool IsBalanced(Node root) {
        return CheckHeight(root) != -1;
    }
    
    private int CheckHeight(Node node) {
        if (node == null) {
            return 0;
        }
        
        int left = CheckHeight(node.left);
        if (left == -1) {
            return -1;
        }
            
        int right = CheckHeight(node.right);
        if (right == -1) {
            return -1;
        }
            
        if (Math.Abs(left - right) > 1) {
            return -1;
        }
            
        return 1 + Math.Max(left, right);
    }

    public void PrintInOrder(Node root) {
        if (root == null) {
            return;
        }
        PrintInOrder(root.left);
        Console.Write(root.val + " ");
        PrintInOrder(root.right);
    }
}
