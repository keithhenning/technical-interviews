def get_height(self, node):
    if not node:
        return 0
    return 1 + max(self.get_height(node.left), 
                  self.get_height(node.right))