#include <string>
#include <vector>
#include <stdexcept>
#include <algorithm>

class Node {
public:
    int position;  // Character position of the line break
    Node* left;
    Node* right;
    int height;    // For AVL tree balance
    
    Node(int pos) : position(pos), left(nullptr), 
                   right(nullptr), height(1) {}
};

class TextEditor {
private:
    std::string text;
    Node* root;  // Root of the AVL tree
    
    // AVL Tree operations
    int getHeight(Node* node) {
        if (node == nullptr) {
            return 0;
        }
        return node->height;
    }
    
    int getBalance(Node* node) {
        if (node == nullptr) {
            return 0;
        }
        return getHeight(node->left) - getHeight(node->right);
    }
    
    Node* rightRotate(Node* y) {
        Node* x = y->left;
        Node* T2 = x->right;
        
        // Perform rotation
        x->right = y;
        y->left = T2;
        
        // Update heights
        y->height = std::max(getHeight(y->left), 
                           getHeight(y->right)) + 1;
        x->height = std::max(getHeight(x->left), 
                           getHeight(x->right)) + 1;
        
        return x;
    }
    
    Node* leftRotate(Node* x) {
        Node* y = x->right;
        Node* T2 = y->left;
        
        // Perform rotation
        y->left = x;
        x->right = T2;
        
        // Update heights
        x->height = std::max(getHeight(x->left), 
                          getHeight(x->right)) + 1;
        y->height = std::max(getHeight(y->left), 
                          getHeight(y->right)) + 1;
        
        return y;
    }
    
    Node* insertNode(Node* node, int position) {
        // Standard BST insert
        if (node == nullptr) {
            return new Node(position);
        }
        
        if (position < node->position) {
            node->left = insertNode(node->left, position);
        } else if (position > node->position) {
            node->right = insertNode(node->right, position);
        } else {
            // Duplicate positions not allowed
            return node;
        }
        
        // Update height of current node
        node->height = std::max(getHeight(node->left), 
                              getHeight(node->right)) + 1;
        
        // Get the balance factor
        int balance = getBalance(node);
        
        // Left Left Case
        if (balance > 1 && 
            position < node->left->position) {
            return rightRotate(node);
        }
        
        // Right Right Case
        if (balance < -1 && 
            position > node->right->position) {
            return leftRotate(node);
        }
        
        // Left Right Case
        if (balance > 1 && 
            position > node->left->position) {
            node->left = leftRotate(node->left);
            return rightRotate(node);
        }
        
        // Right Left Case
        if (balance < -1 && 
            position < node->right->position) {
            node->right = rightRotate(node->right);
            return leftRotate(node);
        }
        
        return node;
    }
    
    Node* getMinValueNode(Node* node) {
        Node* current = node;
        while (current->left != nullptr) {
            current = current->left;
        }
        return current;
    }
    
    Node* deleteNode(Node* node, int position) {
        if (node == nullptr) {
            return node;
        }
        
        if (position < node->position) {
            node->left = deleteNode(node->left, position);
        } else if (position > node->position) {
            node->right = deleteNode(node->right, position);
        } else {
            // Node to be deleted found
            
            // Node with only one child or no child
            if (node->left == nullptr) {
                Node* temp = node->right;
                delete node;
                return temp;
            } else if (node->right == nullptr) {
                Node* temp = node->left;
                delete node;
                return temp;
            }
            
            // Node with two children
            // Get inorder successor (smallest in right subtree)
            Node* successor = getMinValueNode(node->right);
            node->position = successor->position;
            node->right = deleteNode(node->right, 
                                   successor->position);
        }
        
        // If tree had only one node
        if (node == nullptr) {
            return node;
        }
        
        // Update height
        node->height = std::max(getHeight(node->left), 
                              getHeight(node->right)) + 1;
        
        // Get balance factor
        int balance = getBalance(node);
        
        // Rebalance if needed
        // Left Left Case
        if (balance > 1 && getBalance(node->left) >= 0) {
            return rightRotate(node);
        }
        
        // Left Right Case
        if (balance > 1 && getBalance(node->left) < 0) {
            node->left = leftRotate(node->left);
            return rightRotate(node);
        }
        
        // Right Right Case
        if (balance < -1 && getBalance(node->right) <= 0) {
            return leftRotate(node);
        }
        
        // Right Left Case
        if (balance < -1 && getBalance(node->right) > 0) {
            node->right = rightRotate(node->right);
            return leftRotate(node);
        }
        
        return node;
    }
    
    void updatePositions(Node* node, int startPos, int shift) {
        if (node == nullptr) {
            return;
        }
        
        if (node->position >= startPos) {
            node->position += shift;
        }
        
        // Recursively update nodes in the right subtree
        updatePositions(node->right, startPos, shift);
        
        // Only update left subtree if current node is shifted
        if (node->position >= startPos) {
            updatePositions(node->left, startPos, shift);
        }
    }
    
    int countSmaller(Node* node, int position) {
        if (node == nullptr) {
            return 0;
        }
        
        if (position < node->position) {
            return countSmaller(node->left, position);
        } else {
            return 1 + countSmaller(node->left, position) + 
                   countSmaller(node->right, position);
        }
    }
    
    // Helper function to clean up memory
    void deleteTree(Node* node) {
        if (node == nullptr) {
            return;
        }
        
        deleteTree(node->left);
        deleteTree(node->right);
        delete node;
    }

public:
    TextEditor() : root(nullptr) {}
    
    ~TextEditor() {
        deleteTree(root);
    }
    
    void insert(int position, const std::string& str) {
        if (position < 0 || position > text.length()) {
            throw std::invalid_argument("Invalid position");
        }
        
        // Update the text
        text.insert(position, str);
        
        // Find new line breaks in the inserted text
        std::vector<int> newLinePositions;
        for (size_t i = 0; i < str.length(); i++) {
            if (str[i] == '\n') {
                newLinePositions.push_back(position + i);
            }
        }
        
        // Update existing line break positions after insertion
        updatePositions(root, position, str.length());
        
        // Insert new line breaks
        for (int linePos : newLinePositions) {
            root = insertNode(root, linePos);
        }
    }
    
    void remove(int position, int length) {
        if (position < 0 || 
            position + length > static_cast<int>(text.length())) {
            throw std::invalid_argument(
                "Invalid position or length");
        }
        
        // Count line breaks in the deleted text
        std::string deletedText = text.substr(position, length);
        std::vector<int> deletedLines;
        for (size_t i = 0; i < deletedText.length(); i++) {
            if (deletedText[i] == '\n') {
                deletedLines.push_back(position + i);
            }
        }
        
        // Update the text
        text.erase(position, length);
        
        // Delete line breaks in the deleted range
        for (int linePos : deletedLines) {
            root = deleteNode(root, linePos);
        }
        
        // Update line break positions after the deletion
        updatePositions(root, position, -length);
    }
    
    int getLineNumber(int position) {
        if (position < 0 || 
            position > static_cast<int>(text.length())) {
            throw std::invalid_argument("Invalid position");
        }
        
        // Count line breaks before the position
        return countSmaller(root, position);
    }
};