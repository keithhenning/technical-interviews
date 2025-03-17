int countComponents(int n, const std::vector<std::vector<int>>& edges) {
    UnionFind uf(n);
    for (const auto& edge : edges) {
        uf.unionSets(edge[0], edge[1]);
    }
    return uf.getCount();
}