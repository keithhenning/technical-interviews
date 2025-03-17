#include <iostream>
#include <vector>
#include <queue>
#include <stack>
#include <string>

class Graph {
private:
    int V; // Number of vertices
    std::vector<std::vector<int>> adj; // Adjacency list
    
public:
    Graph(int vertices) {
        V = vertices;
        adj.resize(vertices);
    }
    
    // Add directed edge from u to v
    void addEdge(int u, int v) {
        adj[u].push_back(v);
    }
    
    // Kahn's algorithm for topological sorting
    std::vector<int> topologicalSortKahn() {
        std::vector<int> result;
        
        // Calculate in-degree of all vertices
        std::vector<int> inDegree(V, 0);
        for (int u = 0; u < V; u++) {
            for (int v : adj[u]) {
                inDegree[v]++;
            }
        }
        
        // Create a queue and enqueue all vertices with 
        // in-degree 0
        std::queue<int> q;
        for (int i = 0; i < V; i++) {
            if (inDegree[i] == 0) {
                q.push(i);
            }
        }
        
        // Initialize count of visited vertices
        int count = 0;
        
        // Process vertices with in-degree 0
        while (!q.empty()) {
            // Extract front of queue
            int u = q.front();
            q.pop();
            result.push_back(u);
            
            // Reduce in-degree of adjacent vertices by 1
            // If in-degree becomes 0, add to queue
            for (int v : adj[u]) {
                if (--inDegree[v] == 0) {
                    q.push(v);
                }
            }
            
            count++;
        }
        
        // Check if there was a cycle
        if (count != V) {
            std::cout << "There exists a cycle in the graph" 
                      << std::endl;
            return std::vector<int>();
        }
        
        return result;
    }
    
    // Helper function for DFS-based topological sort
    void topologicalSortUtil(int v, std::vector<bool>& visited,
                             std::stack<int>& stack) {
        // Mark current node as visited
        visited[v] = true;
        
        // Recur for all adjacent vertices
        for (int u : adj[v]) {
            if (!visited[u]) {
                topologicalSortUtil(u, visited, stack);
            }
        }
        
        // Push current vertex to stack
        stack.push(v);
    }
    
    // DFS-based topological sorting
    std::vector<int> topologicalSortDFS() {
        std::stack<int> stack;
        std::vector<bool> visited(V, false);
        
        // Call recursive helper for all vertices
        for (int i = 0; i < V; i++) {
            if (!visited[i]) {
                topologicalSortUtil(i, visited, stack);
            }
        }
        
        // Get elements from stack and add to result
        std::vector<int> result;
        while (!stack.empty()) {
            result.push_back(stack.top());
            stack.pop();
        }
        
        return result;
    }
    
    // Print course order with names
    void printCourseOrder(const std::vector<int>& order) {
        std::vector<std::string> courseNames = {
            "Programming Basics", 
            "Computer Architecture",
            "Data Structures", 
            "Discrete Math",
            "Advanced Programming", 
            "Algorithms"
        };
        
        for (int courseId : order) {
            std::cout << courseNames[courseId] << " -> ";
        }
        std::cout << "Graduate!" << std::endl;
    }
};

int main() {
    // Creating a course prerequisite graph
    // 6 courses numbered 0 to 5
    Graph g(6);  
    
    // Adding prerequisites (edges)
    // Algorithms requires Data Structures
    g.addEdge(5, 2);  
    // Algorithms requires Programming Basics
    g.addEdge(5, 0);  
    // Advanced Programming requires Programming Basics
    g.addEdge(4, 0);  
    // Advanced Programming requires Computer Architecture
    g.addEdge(4, 1);  
    // Data Structures requires Discrete Math
    g.addEdge(2, 3);  
    // Discrete Math requires Computer Architecture
    g.addEdge(3, 1);  
    
    // Get course order using Kahn's algorithm
    std::vector<int> courseOrder = g.topologicalSortKahn();
    std::cout << "Course order (Kahn's): ";
    for (int i : courseOrder) {
        std::cout << i << " ";
    }
    std::cout << std::endl;
    g.printCourseOrder(courseOrder);
    
    // Get course order using DFS
    courseOrder = g.topologicalSortDFS();
    std::cout << "\nCourse order (DFS): ";
    for (int i : courseOrder) {
        std::cout << i << " ";
    }
    std::cout << std::endl;
    g.printCourseOrder(courseOrder);
    
    return 0;
}