#include <string>
#include <unordered_map>
#include <algorithm>
#include <cstdint>

struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
};

class Solution {
public:
    int minHeightAfterRemoval(TreeNode* root, int k) {
        std::unordered_map<std::string, int> memo;
        return dfs(root, k, memo);
    }
    
private:
    int dfs(TreeNode* node, int remainingRemovals, 
            std::unordered_map<std::string, int>& memo) {
        if (!node) {
            return 0;
        }
        
        // Check memoization
        std::string key = std::to_string(
                reinterpret_cast<std::uintptr_t>(node)) + 
                ":" + std::to_string(remainingRemovals);
                
        if (memo.find(key) != memo.end()) {
            return memo[key];
        }
        
        // Option 1: Remove this node (and its subtree)
        int heightIfRemoved = 0;  // Height is 0 if node is removed
        
        // Option 2: Keep this node
        int leftHeight = dfs(node->left, remainingRemovals, memo);
        int rightHeight = dfs(node->right, remainingRemovals, memo);
        int heightIfKept = 1 + std::max(leftHeight, rightHeight);
        
        int minHeight = heightIfKept;
        
        // Try removing the node if we have removals left
        if (remainingRemovals > 0) {
            minHeight = std::min(minHeight, heightIfRemoved);
        }
        
        // Try removing left or right subtrees
        if (remainingRemovals > 0) {
            for (int removeLeft = 0; 
                 removeLeft <= remainingRemovals; 
                 removeLeft++) {
                     
                int removeRight = remainingRemovals - removeLeft;
                int heightRemoveSubtrees = 1 + std::max(
                    dfs(node->left, removeLeft, memo),
                    dfs(node->right, removeRight, memo)
                );
                minHeight = std::min(minHeight, 
                                     heightRemoveSubtrees);
            }
        }
        
        memo[key] = minHeight;
        return minHeight;
    }
};