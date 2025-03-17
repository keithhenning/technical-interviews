class TreeNode:
   """Binary tree node."""
   def __init__(self, value):
      self.value = value
      self.left = None
      self.right = None

class DFSTree:
   """Depth-First Search tree traversal."""
   def dfs_recursive(self, root):
      """
      Recursive pre-order DFS traversal.
      
      Time Complexity: O(n)
      Space Complexity: O(h)
      """
      result = []
      
      def explore(node):
         if not node:
            return
         
         # Pre-order: root, left, right
         result.append(node.value)
         explore(node.left)
         explore(node.right)
      
      explore(root)
      return result
   
   def dfs_iterative(self, root):
      """
      Iterative pre-order DFS traversal.
      
      Time Complexity: O(n)
      Space Complexity: O(h)
      """
      if not root:
         return []
      
      result = []
      stack = [root]
      
      while stack:
         node = stack.pop()
         result.append(node.value)
         
         # Right first, then left (stack order)
         if node.right:
            stack.append(node.right)
         if node.left:
            stack.append(node.left)
      
      return result

# Demonstrate DFS traversals
if __name__ == "__main__":
   # Create sample tree
   #        1
   #      /   \
   #     2     3
   #    / \   / \
   #   4   5 6   7
   root = TreeNode(1)
   root.left = TreeNode(2)
   root.right = TreeNode(3)
   root.left.left = TreeNode(4)
   root.left.right = TreeNode(5)
   root.right.left = TreeNode(6)
   root.right.right = TreeNode(7)
   
   # Initialize DFS traversal
   dfs = DFSTree()
   
   # Test recursive and iterative DFS
   print("Recursive DFS:", dfs.dfs_recursive(root))
   print("Iterative DFS:", dfs.dfs_iterative(root))