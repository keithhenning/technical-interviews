#include <iostream>
#include <string>
#include <sstream>
using namespace std;

// Node structure - our building blocks for the tree
struct Node {
    int value;
    Node* left;    // Using left/right instead of 
                   // leftChild/rightChild
    Node* right;
    
    Node(int val) : 
        value(val), 
        left(nullptr), 
        right(nullptr) {}
};

class BinaryTree {
private:
    Node* root;
    
    // Helper method to build our tree output string
    void appendToResult(
        stringstream& result, 
        int value) {
        if (result.tellp() > 0) {
            result << " => ";
        }
        result << value;
    }
    
    // Core traversal logic supporting different orders
    void traverse(
        Node* node, 
        stringstream& result, 
        const string& traversalType) {
        if (!node) return;
        
        if (traversalType == "preorder") {
            appendToResult(result, node->value);
        }
        traverse(node->left, result, traversalType);
        if (traversalType == "inorder") {
            appendToResult(result, node->value);
        }
        traverse(node->right, result, traversalType);
        if (traversalType == "postorder") {
            appendToResult(result, node->value);
        }
    }

public:
    BinaryTree() : root(nullptr) {}
    
    ~BinaryTree() {
        // TODO: Implement proper cleanup
    }
    
    void addChild(int value) {
        // Handle empty tree case
        if (!root) {
            root = new Node(value);
            return;
        }
        
        Node* current = root;
        bool added = false;
        
        while (!added && current) {
            // No duplicates allowed!
            if (value == current->value) {
                cout << "Duplicates cannot be added\n";
                return;
            }
            
            if (value < current->value) {
                if (!current->left) {
                    current->left = new Node(value);
                    added = true;
                } else {
                    current = current->left;
                }
            } else {
                if (!current->right) {
                    current->right = new Node(value);
                    added = true;
                } else {
                    current = current->right;
                }
            }
        }
    }
    
    string removeChild(int value) {
        Node* current = root;
        bool found = false;
        Node* nodeToRemove = nullptr;
        Node* parent = nullptr;
        
        // Find the node to remove
        while (!found) {
            if (!current) {
                return "Node not found";
            }
            
            if (value == current->value) {
                nodeToRemove = current;
                found = true;
            } else if (value < current->value) {
                parent = current;
                current = current->left;
            } else {
                parent = current;
                current = current->right;
            }
        }
        
        cout << "Node found!\n";
        
        // Check if node to remove is parent's left child
        bool isLeftChild = parent->left == nodeToRemove;
        
        // Case 1: Leaf node (no children)
        if (!nodeToRemove->left && !nodeToRemove->right) {
            if (isLeftChild) {
                parent->left = nullptr;
            } else {
                parent->right = nullptr;
            }
            delete nodeToRemove;
        }
        // Case 2: Only has left child
        else if (nodeToRemove->left && !nodeToRemove->right) {
            if (isLeftChild) {
                parent->left = nodeToRemove->left;
            } else {
                parent->right = nodeToRemove->left;
            }
            delete nodeToRemove;
        }
        // Case 3: Only has right child
        else if (nodeToRemove->right && !nodeToRemove->left) {
            if (isLeftChild) {
                parent->left = nodeToRemove->right;
            } else {
                parent->right = nodeToRemove->right;
            }
            delete nodeToRemove;
        }
        // Case 4: Has both children - most complex case!
        else {
            Node* rightSubTree = nodeToRemove->right;
            Node* leftSubTree = nodeToRemove->left;
            
            if (isLeftChild) {
                parent->left = rightSubTree;
            } else {
                parent->right = rightSubTree;
            }
            
            // Find leftmost spot in right subtree
            Node* currLeft = rightSubTree;
            Node* currLeftParent = nullptr;
            bool foundSpace = false;
            
            while (!foundSpace) {
                if (!currLeft) {
                    foundSpace = true;
                } else {
                    currLeftParent = currLeft;
                    currLeft = currLeft->left;
                }
            }
            
            currLeftParent->left = leftSubTree;
            delete nodeToRemove;
            return "Node successfully deleted";
        }
        
        return "Node deleted";
    }
    
    string printTree(const string& traversalType) {
        stringstream result;
        traverse(root, result, traversalType);
        return result.str();
    }
};

// Example usage and testing
int main() {
    BinaryTree tree;
    
    // Test our implementation with some sample values
    tree.addChild(5);
    tree.addChild(3);
    tree.addChild(7);
    tree.addChild(1);
    tree.addChild(9);
    
    cout << "Tree (inorder): " 
         << tree.printTree("inorder") 
         << endl;
    return 0;
}