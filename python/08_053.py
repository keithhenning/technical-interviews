class TreeNode:

    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

def balance_bst(root):
    # Step 1: Collect nodes in sorted order via in-order traversal
    def in_order_traversal(node, nodes):
        if not node:
            return
        in_order_traversal(node.left, nodes)
        nodes.append(node.val)
        in_order_traversal(node.right, nodes)
    
    nodes = []
    in_order_traversal(root, nodes)
    
    # Step 2: Reconstruct balanced BST
    def build_balanced_bst(values, start, end):
        if start > end:
            return None
        
        mid = (start + end) // 2
        node = TreeNode(values[mid])
        
        # Recursively build left and right subtrees
        node.left = build_balanced_bst(values, start, mid - 1)
        node.right = build_balanced_bst(values, mid + 1, end)
        
        return node
    
    return build_balanced_bst(nodes, 0, len(nodes) - 1)