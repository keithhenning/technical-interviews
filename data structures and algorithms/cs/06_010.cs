// Iterative inorder example
public List<int> InorderIterative(TreeNode root)
{
    List<int> result = new List<int>();
    Stack<TreeNode> stack = new Stack<TreeNode>();
    TreeNode current = root;

    while (current != null || stack.Count > 0)
    {
        while (current != null)
        {
            stack.Push(current);
            current = current.Left;
        }
        current = stack.Pop();
        result.Add(current.Value);
        current = current.Right;
    }

    return result;
}
