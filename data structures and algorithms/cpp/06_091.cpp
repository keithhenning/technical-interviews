std::vector<std::vector<int>> kruskalMST(int n,
        std::vector<std::vector<int>>& edges) {
    // Sort edges by weight
    std::sort(edges.begin(), edges.end(),
        [](const std::vector<int>& a, const std::vector<int>& b) {
            return a[2] < b[2];
        });
    
    UnionFind uf(n);
    std::vector<std::vector<int>> mst;
    
    for (const auto& edge : edges) {
        int u = edge[0];
        int v = edge[1];
        int weight = edge[2];
        
        if (uf.unionSets(u, v)) {
            mst.push_back({u, v, weight});
        }
        
        // Early termination when we have n-1 edges
        if (mst.size() == n - 1) {
            break;
        }
    }
    
    return mst;
}