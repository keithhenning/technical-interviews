def inorder_traversal(root):
    if not root:
        return []
    
    result = []
    # Left, Root, Right
    result.extend(inorder_traversal(root.left))
    result.append(root.val)
    result.extend(inorder_traversal(root.right))
    return result