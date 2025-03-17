def dfs_three_ways(node):
    if not node:
        return
        
    # Pre-order: Process BEFORE children
    print(node.value)  # Pre-order
    dfs_three_ways(node.left)
    # In-order: Process BETWEEN children
    print(node.value)  # In-order
    dfs_three_ways(node.right)
    # Post-order: Process AFTER children
    print(node.value)  # Post-order