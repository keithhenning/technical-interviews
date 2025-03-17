class Codec:
  def serialize(self, root):
     # Handle empty tree
     if not root:
        return "null"
     # Serialize tree recursively
     return (
        f"{root.val},{self.serialize(root.left)},"
        f"{self.serialize(root.right)}"
     )
  
  def deserialize(self, data):
     # Recursive deserialization helper
     def dfs():
        val = next(values)
        if val == "null":
           return None
        node = TreeNode(int(val))
        node.left = dfs()
        node.right = dfs()
        return node
     
     # Convert data to iterator
     values = iter(data.split(','))
     return dfs()