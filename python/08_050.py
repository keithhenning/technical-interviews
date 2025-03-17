class TreeNode:

    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

def symmetrize_tree(root):
    if not root:
        return None
    
    # Transform left and right subtrees first
    root.left = symmetrize_tree(root.left)
    root.right = symmetrize_tree(root.right)
    
    # Check if subtrees are symmetric
    if not is_symmetric(root.left, root.right):
        # Not symmetric, make them symmetric
        if root.left and not root.right:
            # Only left child exists, mirror it
            root.right = mirror_tree(root.left)
        elif root.right and not root.left:
            # Only right child exists, mirror it
            root.left = mirror_tree(root.right)
        else:
            # Both children exist but not symmetric
            # Choose left subtree as reference and mirror it
            root.right = mirror_tree(root.left)
    
    return root

def is_symmetric(left, right):
    if not left and not right:
        return True
    if not left or not right:
        return False
    if left.val != right.val:
        return False
    
    return (is_symmetric(left.left, right.right) and
            is_symmetric(left.right, right.left))

def mirror_tree(node):
    if not node:
        return None
    
    # Create a new mirrored node
    mirrored = TreeNode(node.val)
    mirrored.left = mirror_tree(node.right)
    mirrored.right = mirror_tree(node.left)
    
    return mirrored