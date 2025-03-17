std::vector<int> inorder_iterative(Node* root) {
    std::vector<int> result;
    std::stack<Node*> stack;
    Node* current = root;
    
    while (current || !stack.empty()) {
        while (current) {
            stack.push(current);
            current = current->left;
        }
        
        current = stack.top();
        stack.pop();
        result.push_back(current->value);
        current = current->right;
    }
    
    return result;
}