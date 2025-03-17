class Node:
  """Node in a binary search tree."""
  def __init__(self, value):
     # Store node value and child references
     self.value = value
     self.left = None
     self.right = None

class BinaryTree:
  """Binary search tree implementation."""
  def __init__(self):
     # Initialize empty tree
     self.root = None

  def add_child(self, value):
     """Add node to binary search tree."""
     # Handle empty tree
     if not self.root:
        self.root = Node(value)
        return
     
     current = self.root
     while current:
        # Prevent duplicates
        if value == current.value:
           return "Duplicates cannot be added"
        
        # Navigate left for smaller values
        if value < current.value:
           if not current.left:
              current.left = Node(value)
              break
           current = current.left
        
        # Navigate right for larger values
        else:
           if not current.right:
              current.right = Node(value)
              break
           current = current.right

  def remove_child(self, value):
     """Remove node from binary search tree."""
     def _find_successor(node):
        # Find minimum value in right subtree
        current = node.right
        while current.left:
           current = current.left
        return current

     def _remove(current, parent, is_left, value):
        # Node not found
        if not current:
           return "Node not found"

        # Node found
        if value == current.value:
           # Case 1: Leaf node
           if not current.left and not current.right:
              if is_left:
                 parent.left = None
              else:
                 parent.right = None

           # Case 2: One child
           elif not current.right:
              if is_left:
                 parent.left = current.left
              else:
                 parent.right = current.left
           elif not current.left:
              if is_left:
                 parent.left = current.right
              else:
                 parent.right = current.right

           # Case 3: Two children
           else:
              successor = _find_successor(current)
              succ_value = successor.value
              _remove(self.root, None, False, succ_value)
              current.value = succ_value

           return "Node successfully deleted"

        # Recursive search
        if value < current.value:
           return _remove(
              current.left, current, True, value
           )
        return _remove(
           current.right, current, False, value
        )

     # Special case: removing root
     if not self.root:
        return "Tree is empty"

     if self.root.value == value:
        if not self.root.left and not self.root.right:
           self.root = None
        elif not self.root.right:
           self.root = self.root.left
        elif not self.root.left:
           self.root = self.root.right
        else:
           successor = _find_successor(self.root)
           succ_value = successor.value
           _remove(self.root, None, False, succ_value)
           self.root.value = succ_value
        return "Node successfully deleted"

     return _remove(self.root, None, False, value)

  def _traverse(self, node, visit_func, 
                traversal_type='inorder'):
     """Traverse tree with given strategy."""
     if not node:
        return

     if traversal_type == 'preorder':
        visit_func(node)
     self._traverse(
        node.left, visit_func, traversal_type
     )
     if traversal_type == 'inorder':
        visit_func(node)
     self._traverse(
        node.right, visit_func, traversal_type
     )
     if traversal_type == 'postorder':
        visit_func(node)

  def print_tree(self, 
                traversal_type='inorder'):
     """Print tree values."""
     result = []
     def visit_func(node):
        result.append(str(node.value))
     
     self._traverse(
        self.root, visit_func, traversal_type
     )
     return ' => '.join(result)

# Demonstrate binary search tree
if __name__ == "__main__":
  # Create and populate tree
  tree = BinaryTree()
  values = [50, 30, 70, 20, 40, 60, 80]
  for val in values:
     tree.add_child(val)

  print("Inorder:", tree.print_tree())
  print("Preorder:", tree.print_tree('preorder'))
  print("Postorder:", tree.print_tree('postorder'))