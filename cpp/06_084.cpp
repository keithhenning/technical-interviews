#include <iostream>
#include <vector>

class UnionFind {
private:
    std::vector<int> parent;
    std::vector<int> rank;
    int count;
    
public:
    UnionFind(int n) {
        parent.resize(n);
        rank.resize(n);
        count = n;
        
        for (int i = 0; i < n; i++) {
            parent[i] = i;
            rank[i] = 0;
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
        
        // Union by rank
        if (rank[rootX] < rank[rootY]) {
            parent[rootX] = rootY;
        } else if (rank[rootX] > rank[rootY]) {
            parent[rootY] = rootX;
        } else {
            parent[rootY] = rootX;
            rank[rootX]++;
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
};

// Test 1: Friend Circles Test
void testFriendCircles() {
    // Friendship matrix where [i][j] = 1 means i and j are friends
    std::vector<std::vector<int>> friendships = {
        {1, 1, 0, 0},
        {1, 1, 1, 0},
        {0, 1, 1, 0},
        {0, 0, 0, 1}
    };
    
    int n = friendships.size();
    UnionFind uf(n);
    
    // Union friends together
    for (int i = 0; i < n; i++) {
        for (int j = i + 1; j < n; j++) {
            if (friendships[i][j] == 1) {
                uf.unionSets(i, j);
            }
        }
    }
    
    // Count distinct circles (groups)
    int circles = uf.getCount();
    std::cout << "Friend Circles: " << circles << std::endl;
    
    // Print each student's group
    for (int i = 0; i < n; i++) {
        std::cout << "Student " << i << " belongs to group " 
                 << uf.find(i) << std::endl;
    }
}

// Test 2: Network Connectivity Test
void testNetworkConnectivity() {
    // Computer connections
    int n = 6; // 6 computers labeled 0-5
    std::vector<std::vector<int>> connections = {
        {0, 1}, {1, 2}, {3, 4}
    };
    
    UnionFind uf(n);
    
    // Process connections
    for (const auto& connection : connections) {
        uf.unionSets(connection[0], connection[1]);
    }
    
    // Check connectivity
    bool fullyConnected = uf.getCount() == 1;
    std::cout << "Network fully connected: " 
              << (fullyConnected ? "true" : "false") << std::endl;
    
    // Identify isolated components
    std::cout << "Network components:" << std::endl;
    for (int i = 0; i < n; i++) {
        std::cout << "Computer " << i << " is in component " 
                 << uf.find(i) << std::endl;
    }
}

// Test 3: Dynamic Connectivity Test
void testDynamicConnectivity() {
    int n = 5;
    UnionFind uf(n);
    
    std::cout << "Initial components: " << uf.getCount() 
              << std::endl;
    
    // Add connections one by one
    std::vector<std::vector<int>> connections = {
        {0, 1}, {2, 3}, {0, 4}, {3, 4}
    };
    
    for (size_t i = 0; i < connections.size(); i++) {
        int x = connections[i][0];
        int y = connections[i][1];
        
        bool newConnection = uf.unionSets(x, y);
        std::cout << "Connected " << x << " and " << y << 
            ": New connection = " << 
            (newConnection ? "true" : "false") << std::endl;
        std::cout << "Components count: " << uf.getCount() 
                  << std::endl;
        
        // Print current connectivity status
        std::cout << "Current connectivity status:" << std::endl;
        for (int j = 0; j < n; j++) {
            for (int k = j + 1; k < n; k++) {
                std::cout << j << " and " << k << 
                    " connected: " << 
                    (uf.isConnected(j, k) ? "true" : "false") 
                    << std::endl;
            }
        }
        std::cout << std::endl;
    }
}

int main() {
    std::cout << "=== Friend Circles Test ===" << std::endl;
    testFriendCircles();
    
    std::cout << "\n=== Network Connectivity Test ===" 
              << std::endl;
    testNetworkConnectivity();
    
    std::cout << "\n=== Dynamic Connectivity Test ===" 
              << std::endl;
    testDynamicConnectivity();
    
    return 0;
}