#include <iostream>
using namespace std;

enum Color {RED, BLACK};

struct Node {
    int key;
    Color color;
    Node *left, *right, *parent;

    Node(int key) : key(key), color(RED), left(nullptr), right(nullptr), parent(nullptr) {}
};

class RedBlackTree {
private:
    Node *root;
    Node *NIL;

    // Rotations
    void leftRotate(Node *x);
    void rightRotate(Node *x);
    
    // Fix violations introduced by insertion
    void fixInsert(Node *k);
    
    // Helper for inorder traversal
    void inOrderHelper(Node *node);
    
    // Helper for search
    Node* searchHelper(Node *node, int key);

public:
    RedBlackTree() {
        NIL = new Node(0);
        NIL->color = BLACK;
        NIL->left = nullptr;
        NIL->right = nullptr;
        root = NIL;
    }

    ~RedBlackTree() {
        // Proper cleanup would require recursive deletion
        delete NIL;
    }

    void insert(int key);
    void inOrderTraversal();
    Node* search(int key);
};

void RedBlackTree::leftRotate(Node *x) {
    Node *y = x->right;
    x->right = y->left;
    
    if (y->left != NIL) {
        y->left->parent = x;
    }
    
    y->parent = x->parent;
    
    if (x->parent == nullptr) {
        root = y;
    } else if (x == x->parent->left) {
        x->parent->left = y;
    } else {
        x->parent->right = y;
    }
    
    y->left = x;
    x->parent = y;
}

void RedBlackTree::rightRotate(Node *x) {
    Node *y = x->left;
    x->left = y->right;
    
    if (y->right != NIL) {
        y->right->parent = x;
    }
    
    y->parent = x->parent;
    
    if (x->parent == nullptr) {
        root = y;
    } else if (x == x->parent->right) {
        x->parent->right = y;
    } else {
        x->parent->left = y;
    }
    
    y->right = x;
    x->parent = y;
}

void RedBlackTree::insert(int key) {
    Node *node = new Node(key);
    node->left = NIL;
    node->right = NIL;
    
    Node *y = nullptr;
    Node *x = root;
    
    // Find position for new node
    while (x != NIL) {
        y = x;
        if (node->key < x->key) {
            x = x->left;
        } else {
            x = x->right;
        }
    }
    
    // Set parent of node
    node->parent = y;
    
    // If tree is empty, make node the root
    if (y == nullptr) {
        root = node;
    } else if (node->key < y->key) {
        y->left = node;
    } else {
        y->right = node;
    }
    
    // Fix the tree
    fixInsert(node);
}

void RedBlackTree::fixInsert(Node *k) {
    Node *u;
    
    // While parent is red
    while (k != root && k->parent->color == RED) {
        if (k->parent == k->parent->parent->right) {
            u = k->parent->parent->left; // uncle
            
            // Case 1: Uncle is red
            if (u->color == RED) {
                u->color = BLACK;
                k->parent->color = BLACK;
                k->parent->parent->color = RED;
                k = k->parent->parent;
            } else {
                // Case 2: Uncle is black and k is left child
                if (k == k->parent->left) {
                    k = k->parent;
                    rightRotate(k);
                }
                
                // Case 3: Uncle is black and k is right child
                k->parent->color = BLACK;
                k->parent->parent->color = RED;
                leftRotate(k->parent->parent);
            }
        } else {
            u = k->parent->parent->right; // uncle
            
            // Case 1: Uncle is red
            if (u->color == RED) {
                u->color = BLACK;
                k->parent->color = BLACK;
                k->parent->parent->color = RED;
                k = k->parent->parent;
            } else {
                // Case 2: Uncle is black and k is right child
                if (k == k->parent->right) {
                    k = k->parent;
                    leftRotate(k);
                }
                
                // Case 3: Uncle is black and k is left child
                k->parent->color = BLACK;
                k->parent->parent->color = RED;
                rightRotate(k->parent->parent);
            }
        }
    }
    
    // Root must be black
    root->color = BLACK;
}

void RedBlackTree::inOrderTraversal() {
    cout << "In-order traversal of the Red-Black Tree:" << endl;
    inOrderHelper(root);
    cout << endl;
}

void RedBlackTree::inOrderHelper(Node *node) {
    if (node != NIL) {
        inOrderHelper(node->left);
        cout << node->key << "(" << (node->color == RED ? "RED" : "BLACK") << ") ";
        inOrderHelper(node->right);
    }
}

Node* RedBlackTree::search(int key) {
    return searchHelper(root, key);
}

Node* RedBlackTree::searchHelper(Node *node, int key) {
    if (node == NIL || key == node->key) {
        return node;
    }
    
    if (key < node->key) {
        return searchHelper(node->left, key);
    }
    return searchHelper(node->right, key);
}

int main() {
    RedBlackTree rbTree;
    int keys[] = {7, 3, 18, 10, 22, 8, 11, 26};
    int n = sizeof(keys) / sizeof(keys[0]);
    
    for (int i = 0; i < n; i++) {
        rbTree.insert(keys[i]);
    }
    
    rbTree.inOrderTraversal();
    
    int keyToFind = 10;
    Node *foundNode = rbTree.search(keyToFind);
    if (foundNode != nullptr && foundNode != rbTree.NIL) {
        cout << "Found key " << keyToFind << ", color: " 
             << (foundNode->color == RED ? "RED" : "BLACK") << endl;
    } else {
        cout << "Key " << keyToFind << " not found" << endl;
    }
    
    return 0;
}