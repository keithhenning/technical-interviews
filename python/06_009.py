class TreeNode:
   """Node in a binary tree."""
   def __init__(self, val=0):
      # Node value and child references
      self.val = val
      self.left = None
      self.right = None

class BinaryTree:
   """Binary tree with traversal methods."""
   def __init__(self):
      # Initialize empty tree
      self.root = None
   
   def inorder_traversal(self, root):
      """Traverse tree inorder (Left->Root->Right)."""
      result = []
      
      def _inorder(node):
         if node:
            _inorder(node.left)
            result.append(node.val)
            _inorder(node.right)
      
      _inorder(root)
      return result
   
   def preorder_traversal(self, root):
      """Traverse tree preorder (Root->Left->Right)."""
      result = []
      
      def _preorder(node):
         if node:
            result.append(node.val)
            _preorder(node.left)
            _preorder(node.right)
      
      _preorder(root)
      return result
   
   def postorder_traversal(self, root):
      """Traverse tree postorder (Left->Right->Root)."""
      result = []
      
      def _postorder(node):
         if node:
            _postorder(node.left)
            _postorder(node.right)
            result.append(node.val)
      
      _postorder(root)
      return result

# Demonstrate tree traversals
if __name__ == "__main__":
   # Create sample tree
   #        1
   #      /   \
   #     2     3
   #    / \   / \
   #   4   5 6   7
   tree = BinaryTree()
   tree.root = TreeNode(1)
   tree.root.left = TreeNode(2)
   tree.root.right = TreeNode(3)
   tree.root.left.left = TreeNode(4)
   tree.root.left.right = TreeNode(5)
   tree.root.right.left = TreeNode(6)
   tree.root.right.right = TreeNode(7)
   
   # Test traversals
   print("Inorder:   ", tree.inorder_traversal(tree.root))
   print("Preorder:  ", tree.preorder_traversal(tree.root))
   print("Postorder: ", tree.postorder_traversal(tree.root))