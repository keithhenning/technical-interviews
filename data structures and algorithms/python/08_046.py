class TreeNode:
  def __init__(self, val=0, left=None, right=None, 
              connection=None):
     self.val = val
     self.left = left
     self.right = right
     self.connection = connection

def cloneTree(root):
  if not root:
     return None
  
  # Phase 1: Clone tree structure and create mapping
  node_map = {}
  
  def cloneStructure(node):
     if not node:
        return None
     
     if node in node_map:
        return node_map[node]
     
     new_node = TreeNode(node.val)
     node_map[node] = new_node
     
     new_node.left = cloneStructure(node.left)
     new_node.right = cloneStructure(node.right)
     
     return new_node
  
  new_root = cloneStructure(root)
  
  # Phase 2: Set connection pointers
  def setConnections(node):
     if not node:
        return
     
     if node.connection:
        node_map[node].connection = node_map[node.connection]
     
     setConnections(node.left)
     setConnections(node.right)
  
  setConnections(root)
  
  return new_root