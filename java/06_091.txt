public static int[] findRedundantConnection(int[][] edges) {
   int n = edges.length;
   UnionFind uf = new UnionFind(n + 1);
   
   for (int[] edge : edges) {
       int u = edge[0];
       int v = edge[1];
       if (!uf.union(u, v)) {
           return edge;
       }
   }
   
   return new int[0];
}