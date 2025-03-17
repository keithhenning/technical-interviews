class TreeNode:

    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

def matching_path(root1, root2):
    # Collect all paths in the first tree
    paths1 = []
    collect_paths(root1, [], paths1)
    
    # Collect all paths in the second tree
    paths2 = []
    collect_paths(root2, [], paths2)
    
    # Check for matching paths
    for path1 in paths1:
        if path1 in paths2:
            return True
    
    return False

def collect_paths(node, current_path, all_paths):
    if not node:
        return
    
    # Add current node to the path
    current_path.append(node.val)
    
    # If leaf node, add the path to all_paths
    if not node.left and not node.right:
        all_paths.append(current_path.copy())
    else:
        # Continue DFS
        collect_paths(node.left, current_path, all_paths)
        collect_paths(node.right, current_path, all_paths)
    
    # Backtrack
    current_path.pop()