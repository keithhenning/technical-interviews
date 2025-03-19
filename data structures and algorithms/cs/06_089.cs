public static int CountComponents(int n, int[][] edges) {
    UnionFind uf = new UnionFind(n);
    for (int i = 0; i < edges.Length; i++) {
        uf.Union(edges[i][0], edges[i][1]);
    }
    return uf.GetCount();
}