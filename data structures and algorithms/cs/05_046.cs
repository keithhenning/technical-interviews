using System;
using System.Collections.Generic;

public class MainClass {
    public static void Main(string[] args) {
        // Main method code goes here
    }
    
    public class Node {
        public int Val;
        public Node Left;
        public Node Right;
        
        public Node(int val) {
            this.Val = val;
        }
    }
    
    public List<int> InorderTraversal(Node root) {
        if (root == null) {
            return new List<int>();
        }
        
        List<int> result = new List<int>();
        // Left, Root, Right
        result.AddRange(InorderTraversal(root.Left));
        result.Add(root.Val);
        result.AddRange(InorderTraversal(root.Right));
        return result;
    }
}
