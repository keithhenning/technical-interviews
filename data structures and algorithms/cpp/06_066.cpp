#include <vector>
#include <queue>
#include <stack>

class Graph {
private:
    int V;
    vector<vector<int>> adj;
    
public:
    Graph(int vertices) : V(vertices) {
        adj.resize(V);
    }
    
    void addEdge(int u, int v) {
        adj[u].push_back(v);
    }
    
    // Kahn's Algorithm
    vector<int> topologicalSortKahn() {
        vector<int> inDegree(V, 0);
        for (int i = 0; i < V; i++) {
            for (int neighbor : adj[i]) {
                inDegree[neighbor]++;
            }
        }
        
        queue<int> q;
        for (int i = 0; i < V; i++) {
            if (inDegree[i] == 0) {
                q.push(i);
            }
        }
        
        vector<int> result;
        while (!q.empty()) {
            int vertex = q.front();
            q.pop();
            result.push_back(vertex);
            
            for (int neighbor : adj[vertex]) {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) {
                    q.push(neighbor);
                }
            }
        }
        
        return result.size() == V ? result : vector<int>();
    }
    
    // DFS-based Algorithm
    vector<int> topologicalSortDFS() {
        vector<bool> visited(V, false);
        vector<int> result;
        
        function<void(int)> dfs = [&](int v) {
            visited[v] = true;
            for (int neighbor : adj[v]) {
                if (!visited[neighbor]) {
                    dfs(neighbor);
                }
            }
            result.insert(result.begin(), v);
        };
        
        for (int i = 0; i < V; i++) {
            if (!visited[i]) {
                dfs(i);
            }
        }
        
        return result;
    }
};