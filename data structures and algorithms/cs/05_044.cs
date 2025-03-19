using System;
using System.Collections.Generic;

public class BinaryTree
{
    private Node Root { get; set; }

    public bool IsEmpty()
    {
        return this.Root == null;
    }

    public IEnumerable<Node> InOrderTraversal()
    {
        if (Root == null) yield break;
        var stack = new Stack<Node>();
        var current = Root;

        while (stack.Count > 0 || current != null)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();
            yield return current;
            current = current.Right;
        }
    }

    public void PrintTree()
    {
        foreach (var node in InOrderTraversal())
        {
            Console.Write($"{node.Data} ");
        }
        Console.WriteLine();
    }
}
