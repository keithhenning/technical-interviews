std::vector<int> findRedundantConnection(
        const std::vector<std::vector<int>>& edges) {
    int n = edges.size();
    UnionFind uf(n + 1);
    
    for (const auto& edge : edges) {
        int u = edge[0];
        int v = edge[1];
        if (!uf.unionSets(u, v)) {
            return edge;
        }
    }
    
    return {};
}