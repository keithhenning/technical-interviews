public static int friendCircles(int[][] M) {
   int n = M.length;
   UnionFind uf = new UnionFind(n);
   
   for (int i = 0; i < n; i++) {
       for (int j = i+1; j < n; j++) {
           if (M[i][j] == 1) {
               uf.union(i, j);
           }
       }
   }
   
   return uf.getCount();
}