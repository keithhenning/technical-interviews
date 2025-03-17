class BSTIterator:
    def __init__(self, root):
        self.stack = []
        self._leftmost_inorder(root)
        
    def _leftmost_inorder(self, root):
        while root:
            self.stack.append(root)
            root = root.left
    
    def next(self):
        topmost_node = self.stack.pop()
        if topmost_node.right:
            self._leftmost_inorder(topmost_node.right)
        return topmost_node.key
    
    def has_next(self):
        return len(self.stack) > 0