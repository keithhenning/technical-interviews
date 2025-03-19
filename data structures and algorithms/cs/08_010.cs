using System;
using System.Collections.Generic;

public class LevelOrderTraversal {
    // Definition for a binary tree node
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        
        public TreeNode(int x) {
            val = x;
        }
    }
    
    public static List<List<int>> LevelOrder(TreeNode root) {
        List<List<int>> result = new List<List<int>>();
        if (root == null) return result;
        
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count > 0) {
            int levelSize = queue.Count;
            List<int> currentLevel = new List<int>();
            
            for (int i = 0; i < levelSize; i++) {
                TreeNode node = queue.Dequeue();
                currentLevel.Add(node.val);
                
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            
            result.Add(currentLevel);
        }
        
        return result;
    }
    
    public static void Main(string[] args) {
        // Construct the tree [3,9,20,null,null,15,7]
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(7);
        
        Console.WriteLine(string.Join(", ", LevelOrder(root).Select(level => string.Join(", ", level))));  // [[3],[9,20],[15,7]]
    }
}