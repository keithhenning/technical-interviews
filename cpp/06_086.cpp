#include <iostream>
#include <vector>

class UnionFind {
private:
    std::vector<int> parent;
    std::vector<int> size;  // Each set initially has size 1
    int count;
    
public:
    UnionFind(int n) {
        parent.resize(n);
        size.resize(n);
        count = n;
        
        for (int i = 0; i < n; i++) {
            parent[i] = i;
            size[i] = 1;
        }
    }
    
    int find(int x) {
        if (parent[x] != x) {
            parent[x] = find(parent[x]);  // Path compression
        }
        return parent[x];
    }
    
    bool unionSets(int x, int y) {
        int rootX = find(x);
        int rootY = find(y);
        
        if (rootX == rootY) {
            return false;
        }
        
        // Attach smaller tree to the root of larger tree
        if (size[rootX] < size[rootY]) {
            parent[rootX] = rootY;
            size[rootY] += size[rootX];
        } else {
            parent[rootY] = rootX;
            size[rootX] += size[rootY];
        }
        
        count--;
        return true;
    }
    
    bool isConnected(int x, int y) {
        return find(x) == find(y);
    }
    
    int getCount() {
        return count;
    }
    
    int getSize(int x) {
        return size[find(x)];
    }
};