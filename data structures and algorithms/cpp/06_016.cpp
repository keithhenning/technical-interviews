// Bad: Using vector as queue - erase(begin()) is O(n)
std::vector<TreeNode*> badQueue;
// Usage:
badQueue.push_back(node);         // Add to back
TreeNode* node = badQueue.front(); // Get front element
badQueue.erase(badQueue.begin());  // Remove front - expensive!

// Good: Using std::queue - pop() is O(1)
std::queue<TreeNode*> goodQueue;
// Usage:
goodQueue.push(node);       // Add to back
TreeNode* node = goodQueue.front(); // Get front element
goodQueue.pop();