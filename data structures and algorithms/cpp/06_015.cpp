#include <iostream>

// Add this to your main function

// Test empty tree
TreeNode* emptyRoot = nullptr;
// Should print: []
std::cout << "Empty tree: ";
std::vector<std::vector<int>> emptyResult = 
    bfs.breadthFirstSearch(emptyRoot);
if (emptyResult.empty()) {
    std::cout << "[]" << std::endl;
} else {
    // Print using the same format as before
    for (const auto& level : emptyResult) {
        std::cout << "[";
        for (size_t i = 0; i < level.size(); i++) {
            std::cout << level[i];
            if (i < level.size() - 1) std::cout << ", ";
        }
        std::cout << "] ";
    }
    std::cout << std::endl;
}

// Test single node tree
TreeNode* singleNode = new TreeNode(42);
// Should print: [[42]]
std::cout << "Single node tree: ";
std::vector<std::vector<int>> singleResult = 
    bfs.breadthFirstSearch(singleNode);
for (const auto& level : singleResult) {
    std::cout << "[";
    for (size_t i = 0; i < level.size(); i++) {
        std::cout << level[i];
        if (i < level.size() - 1) std::cout << ", ";
    }
    std::cout << "] ";
}
std::cout << std::endl;

// Don't forget to clean up
delete singleNode;