using System;
using System.Collections.Generic;

public class Node
{
    public int Key { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int key)
    {
        this.Key = key;
    }
}

public class BSTIterator
{
    private Stack<Node> stack;

    public BSTIterator(Node root)
    {
        this.stack = new Stack<Node>();
        this.LeftmostInorder(root);
    }

    private void LeftmostInorder(Node root)
    {
        while (root != null)
        {
            this.stack.Push(root);
            root = root.Left;
        }
    }

    public int Next()
    {
        Node topmostNode = this.stack.Pop();
        if (topmostNode.Right != null)
        {
            this.LeftmostInorder(topmostNode.Right);
        }
        return topmostNode.Key;
    }

    public bool HasNext()
    {
        return this.stack.Count > 0;
    }
}
