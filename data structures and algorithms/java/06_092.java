public static List<int[]> kruskalMST(int n, int[][] edges) {
    // Sort edges by weight
    Arrays.sort(edges, (a, b) -> Integer.compare(a[2], b[2]));
    
    UnionFind uf = new UnionFind(n);
    List<int[]> mst = new ArrayList<>();
    
    for (int[] edge : edges) {
        int u = edge[0];
        int v = edge[1];
        int weight = edge[2];
        
        if (uf.union(u, v)) {
            mst.add(new int[]{u, v, weight});
        }
        
        // Early termination when we have n-1 edges
        if (mst.size() == n - 1) {
            break;
        }
    }
    
    return mst;
}