using System;
using System.Collections.Generic;

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
    
    public List<int> InorderIterative(Node root) {
        List<int> result = new List<int>();
        Stack<Node> stack = new Stack<Node>();
        Node current = root;
        
        while (current != null || stack.Count > 0) {
            while (current != null) {
                stack.Push(current);
                current = current.left;
            }
            
            current = stack.Pop();
            result.Add(current.val);
            current = current.right;
        }
        
        return result;
    }

    public void PrintPreOrder(Node root) {
        if (root == null) {
            return;
        }
        Console.Write(root.val + " ");
        PrintPreOrder(root.left);
        PrintPreOrder(root.right);
    }
}
