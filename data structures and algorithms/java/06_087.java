// Inside the UnionFind class, replace rank with size
public UnionFind(int n) {
   parent = new int[n];
   size = new int[n];  // Each set initially has size 1
   count = n;
   
   for (int i = 0; i < n; i++) {
       parent[i] = i;
       size[i] = 1;
   }
}

public boolean union(int x, int y) {
   int rootX = find(x);
   int rootY = find(y);
   
   if (rootX == rootY) {
       return false;
   }
   
   // Attach smaller tree to the root of larger tree
   if (size[rootX] < size[rootY]) {
       parent[rootX] = rootY;
       size[rootY] += size[rootX];
   } else {
       parent[rootY] = rootX;
       size[rootX] += size[rootY];
   }
   
   count--;
   return true;
}