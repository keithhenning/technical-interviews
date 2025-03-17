class BSTIterator {
private:
    std::stack<Node*> stack;
    
    void _leftmost_inorder(Node* root) {
        while (root) {
            stack.push(root);
            root = root->left;
        }
    }
    
public:
    BSTIterator(Node* root) {
        _leftmost_inorder(root);
    }
    
    int next() {
        Node* topmost_node = stack.top();
        stack.pop();
        
        if (topmost_node->right) {
            _leftmost_inorder(topmost_node->right);
        }
        
        return topmost_node->value;
    }
    
    bool has_next() {
        return !stack.empty();
    }
};