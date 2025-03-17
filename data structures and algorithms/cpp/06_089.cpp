int friendCircles(const std::vector<std::vector<int>>& M) {
    int n = M.size();
    UnionFind uf(n);
    
    for (int i = 0; i < n; i++) {
        for (int j = i+1; j < n; j++) {
            if (M[i][j] == 1) {
                uf.unionSets(i, j);
            }
        }
    }
    
    return uf.getCount();
}