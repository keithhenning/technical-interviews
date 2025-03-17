/**
 * Main method to demonstrate UnionFind
 */
public static void main(String[] args) {
   // Initialize with 10 elements (0-9)
   UnionFind uf = new UnionFind(10);
   
   // Connect elements
   uf.union(0, 1);
   uf.union(1, 2);
   uf.union(3, 4);
   
   // Check connectivity
   System.out.println(uf.isConnected(0, 2) ? "true" : 
      "false"); // true
   System.out.println(uf.isConnected(0, 4) ? "true" : 
      "false"); // false
   
   // Number of disjoint sets
   System.out.println(uf.getCount()); // 7
}