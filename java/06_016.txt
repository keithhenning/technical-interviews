// Bad: Using ArrayList as queue - remove(0) is O(n)
List<TreeNode> queue = new ArrayList<>();

// Good: Using ArrayDeque - pollFirst() is O(1)  
Deque<TreeNode> queue = new ArrayDeque<>();