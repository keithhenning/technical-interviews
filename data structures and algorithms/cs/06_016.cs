// Bad: Using List as queue - RemoveAt(0) is O(n)
List<TreeNode> queue = new List<TreeNode>();

// Good: Using Queue - Dequeue() is O(1)
Queue<TreeNode> queue = new Queue<TreeNode>();
