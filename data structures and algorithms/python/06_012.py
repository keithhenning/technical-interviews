from collections import deque

class TreeNode:
   """Binary tree node."""
   def __init__(self, value):
      # Node value and child references
      self.value = value
      self.left = None
      self.right = None

def breadth_first_search(root):
   """
   Perform level-order traversal of binary tree.
   
   Returns nodes level by level, left to right.
   
   Time Complexity: O(n)
   Space Complexity: O(w)
   """
   if not root:
      return []
   
   result = []
   queue = deque([root])
   
   while queue:
      # Process current level
      level_size = len(queue)
      current_level = []
      
      for _ in range(level_size):
         # Process nodes at current level
         node = queue.popleft()
         current_level.append(node.value)
         
         # Queue children for next level
         if node.left:
            queue.append(node.left)
         if node.right:
            queue.append(node.right)
      
      result.append(current_level)
   
   return result