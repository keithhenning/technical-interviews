#include <iostream>

int main() {
    // Initialize with 10 elements (0-9)
    UnionFind uf(10);
    
    // Connect elements
    uf.unionSets(0, 1);
    uf.unionSets(1, 2);
    uf.unionSets(3, 4);
    
    // Check if connected
    std::cout << (uf.isConnected(0, 2) ? "true" : "false")
              << std::endl;  // true
    std::cout << (uf.isConnected(0, 4) ? "true" : "false")
              << std::endl;  // false
    
    // Number of disjoint sets
    std::cout << uf.getCount() << std::endl;  // 7
    
    return 0;
}