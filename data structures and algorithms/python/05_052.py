def kth_smallest(root, k):
    # Perform inorder traversal and return the kth element
    result = []
    
    def inorder(node):
        if not node or len(result) >= k:
            return
        inorder(node.left)
        result.append(node.key)
        inorder(node.right)
    
    inorder(root)
    return result[k-1] if k <= len(result) else None