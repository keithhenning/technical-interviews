class TreeNode:

    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

def min_height_after_removal(root, k):
    memo = {}  # Memoization to avoid recalculating
    
    def dfs(node, remaining_removals):
        if not node:
            return 0
        
        # Check memoization
        key = (id(node), remaining_removals)
        if key in memo:
            return memo[key]
        
        # Option 1: Remove this node (and its subtree)
        height_if_removed = 0  # Height is 0 if node is removed
        
        # Option 2: Keep this node
        left_height = dfs(node.left, remaining_removals)
        right_height = dfs(node.right, remaining_removals)
        height_if_kept = 1 + max(left_height, right_height)
        
        min_height = height_if_kept
        
        # Try removing the node if we have removals left
        if remaining_removals > 0:
            min_height = min(min_height, height_if_removed)
        
        # Try removing left or right subtrees
        if remaining_removals > 0:
            for remove_left in range(remaining_removals + 1):
                remove_right = remaining_removals - remove_left
                height_remove_subtrees = 1 + max(
                    dfs(node.left, remove_left),
                    dfs(node.right, remove_right)
                )
                min_height = min(min_height, height_remove_subtrees)
        
        memo[key] = min_height
        return min_height
    
    return dfs(root, k)