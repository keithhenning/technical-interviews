bool is_balanced(Node* root) {
    // Returns height if balanced, -1 if not balanced
    std::function<int(Node*)> check_height = 
        [&](Node* node) -> int {
        if (!node) {
            return 0;
        }
        
        int left = check_height(node->left);
        if (left == -1) {
            return -1;
        }
            
        int right = check_height(node->right);
        if (right == -1) {
            return -1;
        }
            
        if (std::abs(left - right) > 1) {
            return -1;
        }
            
        return 1 + std::max(left, right);
    };
    
    return check_height(root) != -1;
}