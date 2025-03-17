class Node:
   def __init__(self, key):
      # Initialize node with key and default properties
      self.key = key
      self.left = None
      self.right = None
      self.parent = None
      self.color = "RED"  # New nodes are always red


class RedBlackTree:
   def __init__(self):
      # Create sentinel NIL node
      self.NIL = Node(0)
      self.NIL.color = "BLACK"
      self.NIL.left = None
      self.NIL.right = None
      self.root = self.NIL

   def insert(self, key):
      # Create new node
      node = Node(key)
      node.left = self.NIL
      node.right = self.NIL

      y = None
      x = self.root

      # Find position for new node
      while x != self.NIL:
         y = x
         if node.key < x.key:
            x = x.left
         else:
            x = x.right

      # Set parent of node
      node.parent = y
      
      # If tree is empty, make node the root
      if y is None:
         self.root = node
         node.color = "BLACK"  # Root must be black
         return
      # Otherwise, link node to its parent
      elif node.key < y.key:
         y.left = node
      else:
         y.right = node

      # If grandparent is None, return
      if node.parent.parent is None:
         return

      # Fix the tree to maintain Red-Black properties
      self._fix_insert(node)

   def _fix_insert(self, k):
      # Fix Red-Black Tree properties after insertion
      while k.parent and k.parent.color == "RED":
         # If parent is right child of grandparent
         if k.parent == k.parent.parent.right:
            u = k.parent.parent.left  # uncle
            
            # Case 1: Uncle is red
            if u.color == "RED":
               u.color = "BLACK"
               k.parent.color = "BLACK"
               k.parent.parent.color = "RED"
               k = k.parent.parent
            else:
               # Case 2: Uncle is black and k is left child
               if k == k.parent.left:
                  k = k.parent
                  self._right_rotate(k)
               
               # Case 3: Uncle is black and k is right child
               k.parent.color = "BLACK"
               k.parent.parent.color = "RED"
               self._left_rotate(k.parent.parent)
         else:
            # If parent is left child of grandparent
            u = k.parent.parent.right  # uncle
            
            # Case 1: Uncle is red
            if u.color == "RED":
               u.color = "BLACK"
               k.parent.color = "BLACK"
               k.parent.parent.color = "RED"
               k = k.parent.parent
            else:
               # Case 2: Uncle is black and k is right child
               if k == k.parent.right:
                  k = k.parent
                  self._left_rotate(k)
               
               # Case 3: Uncle is black and k is left child
               k.parent.color = "BLACK"
               k.parent.parent.color = "RED"
               self._right_rotate(k.parent.parent)
         
         # If k is the root, break
         if k == self.root:
            break
      
      # Root must be black
      self.root.color = "BLACK"

   def _left_rotate(self, x):
      # Perform left rotation
      y = x.right
      x.right = y.left
      
      if y.left != self.NIL:
         y.left.parent = x

      y.parent = x.parent
      
      if x.parent is None:
         self.root = y
      elif x == x.parent.left:
         x.parent.left = y
      else:
         x.parent.right = y
         
      y.left = x
      x.parent = y

   def _right_rotate(self, x):
      # Perform right rotation
      y = x.left
      x.left = y.right
      
      if y.right != self.NIL:
         y.right.parent = x

      y.parent = x.parent
      
      if x.parent is None:
         self.root = y
      elif x == x.parent.right:
         x.parent.right = y
      else:
         x.parent.left = y
         
      y.right = x
      x.parent = y

   def in_order_traversal(self, node):
      # Perform in-order traversal
      result = []
      if node != self.NIL:
         result = self.in_order_traversal(node.left)
         result.append((node.key, node.color))
         result += self.in_order_traversal(node.right)
      return result

   def search(self, key):
      # Search for a key in the tree
      return self._search_helper(self.root, key)
   
   def _search_helper(self, node, key):
      # Helper function for search
      if node == self.NIL or key == node.key:
         return node
      
      if key < node.key:
         return self._search_helper(node.left, key)
      return self._search_helper(node.right, key)

# Example usage
if __name__ == "__main__":
   rb_tree = RedBlackTree()
   keys = [7, 3, 18, 10, 22, 8, 11, 26]
   
   for key in keys:
      rb_tree.insert(key)
   
   print("In-order traversal of the Red-Black Tree:")
   print(rb_tree.in_order_traversal(rb_tree.root))
   
   # Find a key
   key_to_find = 10
   found_node = rb_tree.search(key_to_find)
   if found_node != rb_tree.NIL:
      print(f"Found key {key_to_find}, color: "
           f"{found_node.color}")
   else:
      print(f"Key {key_to_find} not found")