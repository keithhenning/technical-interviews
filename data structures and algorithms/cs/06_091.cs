public static int[] FindRedundantConnection(int[][] edges) {
    int n = edges.Length;
    UnionFind uf = new UnionFind(n + 1);

    foreach (int[] edge in edges) {
        int u = edge[0];
        int v = edge[1];
        if (!uf.Union(u, v)) {
            return edge;
        }
    }

    return new int[0];
}