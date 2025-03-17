class Node:
   def __init__(self, position):
      self.position = position
      self.left = None
      self.right = None
      self.height = 1

class TextEditor:
   def __init__(self):
      self.text = ""
      self.root = None
   
   def insert(self, position, text):
      if position < 0 or position > len(self.text):
         raise ValueError("Invalid position")
      
      self.text = self.text[:position] + text + self.text[position:]
      
      new_line_positions = [position + i for i, char in 
                          enumerate(text) if char == '\n']
      text_length = len(text)
      
      self._update_positions(self.root, position, text_length)
      
      for line_pos in new_line_positions:
         self.root = self._insert_node(self.root, line_pos)
   
   def delete(self, position, length):
      if position < 0 or position + length > len(self.text):
         raise ValueError("Invalid position or length")
      
      deleted_text = self.text[position:position + length]
      deleted_lines = [position + i for i, char in 
                     enumerate(deleted_text) if char == '\n']
      
      self.text = self.text[:position] + self.text[position + length:]
      
      for line_pos in deleted_lines:
         self.root = self._delete_node(self.root, line_pos)
      
      self._update_positions(self.root, position, -length)
   
   def getLineNumber(self, position):
      if position < 0 or position > len(self.text):
         raise ValueError("Invalid position")
      
      return self._count_smaller(self.root, position)
   
   def _get_height(self, node):
      if not node:
         return 0
      return node.height
   
   def _get_balance(self, node):
      if not node:
         return 0
      return self._get_height(node.left) - self._get_height(node.right)
   
   def _right_rotate(self, y):
      x = y.left
      T2 = x.right
      
      x.right = y
      y.left = T2
      
      y.height = max(self._get_height(y.left), 
                   self._get_height(y.right)) + 1
      x.height = max(self._get_height(x.left), 
                   self._get_height(x.right)) + 1
      
      return x
   
   def _left_rotate(self, x):
      y = x.right
      T2 = y.left
      
      y.left = x
      x.right = T2
      
      x.height = max(self._get_height(x.left), 
                   self._get_height(x.right)) + 1
      y.height = max(self._get_height(y.left), 
                   self._get_height(y.right)) + 1
      
      return y
   
   def _insert_node(self, node, position):
      if not node:
         return Node(position)
      
      if position < node.position:
         node.left = self._insert_node(node.left, position)
      elif position > node.position:
         node.right = self._insert_node(node.right, position)
      else:
         return node
      
      node.height = max(self._get_height(node.left), 
                      self._get_height(node.right)) + 1
      
      balance = self._get_balance(node)
      
      if balance > 1 and position < node.left.position:
         return self._right_rotate(node)
      
      if balance < -1 and position > node.right.position:
         return self._left_rotate(node)
      
      if balance > 1 and position > node.left.position:
         node.left = self._left_rotate(node.left)
         return self._right_rotate(node)
      
      if balance < -1 and position < node.right.position:
         node.right = self._right_rotate(node.right)
         return self._left_rotate(node)
      
      return node
   
   def _delete_node(self, node, position):
      if not node:
         return node
      
      if position < node.position:
         node.left = self._delete_node(node.left, position)
      elif position > node.position:
         node.right = self._delete_node(node.right, position)
      else:
         if not node.left:
            return node.right
         elif not node.right:
            return node.left
         
         successor = self._get_min_value_node(node.right)
         node.position = successor.position
         node.right = self._delete_node(node.right, 
                                      successor.position)
      
      if not node:
         return node
      
      node.height = max(self._get_height(node.left), 
                      self._get_height(node.right)) + 1
      
      balance = self._get_balance(node)
      
      if balance > 1 and self._get_balance(node.left) >= 0:
         return self._right_rotate(node)
      
      if balance > 1 and self._get_balance(node.left) < 0:
         node.left = self._left_rotate(node.left)
         return self._right_rotate(node)
      
      if balance < -1 and self._get_balance(node.right) <= 0:
         return self._left_rotate(node)
      
      if balance < -1 and self._get_balance(node.right) > 0:
         node.right = self._right_rotate(node.right)
         return self._left_rotate(node)
      
      return node
   
   def _get_min_value_node(self, node):
      current = node
      while current.left:
         current = current.left
      return current
   
   def _update_positions(self, node, start_pos, shift):
      if not node:
         return
      
      if node.position >= start_pos:
         node.position += shift
      
      self._update_positions(node.right, start_pos, shift)
      
      if node.position >= start_pos:
         self._update_positions(node.left, start_pos, shift)
   
   def _count_smaller(self, node, position):
      if not node:
         return 0
      
      if position < node.position:
         return self._count_smaller(node.left, position)
      else:
         return (1 + self._count_smaller(node.left, position) + 
                self._count_smaller(node.right, position))