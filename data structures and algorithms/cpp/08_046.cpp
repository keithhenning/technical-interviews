#include <unordered_map>

struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode* connection;
    
    TreeNode(int x) : val(x), left(nullptr), right(nullptr),
                      connection(nullptr) {}
};

class Solution {
public:
    TreeNode* cloneTree(TreeNode* root) {
        if (!root) {
            return nullptr;
        }
        
        // Phase 1: Clone tree structure and create mapping
        std::unordered_map<TreeNode*, TreeNode*> nodeMap;
        
        // Create a copy of the original tree
        TreeNode* newRoot = cloneStructure(root, nodeMap);
        
        // Phase 2: Set connection pointers
        setConnections(root, nodeMap);
        
        return newRoot;
    }
    
private:
    TreeNode* cloneStructure(
        TreeNode* node, 
        std::unordered_map<TreeNode*, TreeNode*>& nodeMap) {
        
        if (!node) {
            return nullptr;
        }
        
        if (nodeMap.find(node) != nodeMap.end()) {
            return nodeMap[node];
        }
        
        TreeNode* newNode = new TreeNode(node->val);
        nodeMap[node] = newNode;
        
        newNode->left = cloneStructure(node->left, nodeMap);
        newNode->right = cloneStructure(node->right, nodeMap);
        
        return newNode;
    }
    
    void setConnections(
        TreeNode* originalNode,
        std::unordered_map<TreeNode*, TreeNode*>& nodeMap) {
        
        if (!originalNode) {
            return;
        }
        
        if (originalNode->connection) {
            nodeMap[originalNode]->connection = 
                nodeMap[originalNode->connection];
        }
        
        setConnections(originalNode->left, nodeMap);
        setConnections(originalNode->right, nodeMap);
    }
};