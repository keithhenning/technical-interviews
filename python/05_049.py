def is_balanced(root):
    def check_height(node):
        if not node:
            return 0
        
        left = check_height(node.left)
        if left == -1:
            return -1
            
        right = check_height(node.right)
        if right == -1:
            return -1
            
        if abs(left - right) > 1:
            return -1
            
        return 1 + max(left, right)
    
    return check_height(root) != -1