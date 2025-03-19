using System;
using System.Collections.Generic;

public class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        this.Value = value;
        this.Left = null;
        this.Right = null;
    }
}

public class DFSTree
{
    public List<int> DfsRecursive(TreeNode root)
    {
        List<int> result = new List<int>();
        DfsRecursiveHelper(root, result);
        return result;
    }

    private void DfsRecursiveHelper(TreeNode node, List<int> result)
    {
        if (node == null) return;
        result.Add(node.Value);
        DfsRecursiveHelper(node.Left, result);
        DfsRecursiveHelper(node.Right, result);
    }

    public List<int> DfsIterative(TreeNode root)
    {
        List<int> result = new List<int>();
        if (root == null) return result;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            TreeNode node = stack.Pop();
            result.Add(node.Value);

            if (node.Right != null) stack.Push(node.Right);
            if (node.Left != null) stack.Push(node.Left);
        }

        return result;
    }
}

public class Program
{
    public static void Main()
    {
        // Create our test tree
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(5);
        root.Left.Left = new TreeNode(3);
        root.Left.Right = new TreeNode(4);
        root.Right.Right = new TreeNode(6);
        root.Right.Right.Left = new TreeNode(7);

        // Initialize our DFS tree traversal object
        DFSTree dfsTree = new DFSTree();

        // Test both methods and compare results
        List<int> recursiveResult = dfsTree.DfsRecursive(root);
        List<int> iterativeResult = dfsTree.DfsIterative(root);

        // Should print: [1, 2, 3, 4, 5, 6, 7]
        Console.WriteLine("Recursive DFS: " + string.Join(", ", recursiveResult));
        // Should print: [1, 2, 3, 4, 5, 6, 7]
        Console.WriteLine("Iterative DFS: " + string.Join(", ", iterativeResult));

        // Let's also test some edge cases I've learned are important:
        Console.WriteLine("\nTesting edge cases:");

        // Empty tree
        TreeNode emptyRoot = null;
        // Should print: []
        Console.WriteLine("Empty tree (recursive): " + string.Join(", ", dfsTree.DfsRecursive(emptyRoot)));
        // Should print: []
        Console.WriteLine("Empty tree (iterative): " + string.Join(", ", dfsTree.DfsIterative(emptyRoot)));

        // Single node tree
        TreeNode singleNode = new TreeNode(42);
        // Should print: [42]
        Console.WriteLine("Single node (recursive): " + string.Join(", ", dfsTree.DfsRecursive(singleNode)));
        // Should print: [42]
        Console.WriteLine("Single node (iterative): " + string.Join(", ", dfsTree.DfsIterative(singleNode)));

        // Linear tree (only left children)
        TreeNode linearRoot = new TreeNode(1);
        linearRoot.Left = new TreeNode(2);
        linearRoot.Left.Left = new TreeNode(3);
        // Should print: [1, 2, 3]
        Console.WriteLine("Linear tree (recursive): " + string.Join(", ", dfsTree.DfsRecursive(linearRoot)));
        // Should print: [1, 2, 3]
        Console.WriteLine("Linear tree (iterative): " + string.Join(", ", dfsTree.DfsIterative(linearRoot)));
    }
}
