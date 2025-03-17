public class UnionFind {
   private int[] parent;
   private int[] rank;
   private int count;
   
   /**
    * Initialize UnionFind with n elements
    */
   public UnionFind(int n) {
      parent = new int[n];
      rank = new int[n];
      count = n;
      
      // Each element starts in its own set
      for (int i = 0; i < n; i++) {
         parent[i] = i;
         rank[i] = 0;
      }
   }
   
   /**
    * Find the representative of element x
    */
   public int find(int x) {
      if (parent[x] != x) {
         // Path compression optimization
         parent[x] = find(parent[x]);
      }
      return parent[x];
   }
   
   /**
    * Merge sets containing elements x and y
    */
   public boolean union(int x, int y) {
      int rootX = find(x);
      int rootY = find(y);
      
      // Already in same set
      if (rootX == rootY) {
         return false;
      }
      
      // Union by rank optimization
      if (rank[rootX] < rank[rootY]) {
         parent[rootX] = rootY;
      } else if (rank[rootX] > rank[rootY]) {
         parent[rootY] = rootX;
      } else {
         parent[rootY] = rootX;
         rank[rootX]++;
      }
      
      count--;
      return true;
   }
   
   /**
    * Check if elements x and y are in same set
    */
   public boolean isConnected(int x, int y) {
      return find(x) == find(y);
   }
   
   /**
    * Get number of disjoint sets
    */
   public int getCount() {
      return count;
   }
   
   /**
    * Test 1: Friend Circles
    */
   public static void testFriendCircles() {
      // Friendship matrix
      int[][] friendships = {
         {1, 1, 0, 0},
         {1, 1, 1, 0},
         {0, 1, 1, 0},
         {0, 0, 0, 1}
      };
      
      int n = friendships.length;
      UnionFind uf = new UnionFind(n);
      
      // Union friends
      for (int i = 0; i < n; i++) {
         for (int j = i + 1; j < n; j++) {
            if (friendships[i][j] == 1) {
               uf.union(i, j);
            }
         }
      }
      
      // Count circles
      int circles = uf.getCount();
      System.out.println("Friend Circles: " + circles);
      
      // Print group memberships
      for (int i = 0; i < n; i++) {
         System.out.println("Student " + i + 
            " belongs to group " + uf.find(i));
      }
   }
   
   /**
    * Test 2: Network Connectivity
    */
   public static void testNetworkConnectivity() {
      int n = 6; // 6 computers
      int[][] connections = {
         {0, 1}, {1, 2}, {3, 4}
      };
      
      UnionFind uf = new UnionFind(n);
      
      // Process connections
      for (int[] connection : connections) {
         uf.union(connection[0], connection[1]);
      }
      
      // Check full connectivity
      boolean fullyConnected = uf.getCount() == 1;
      System.out.println("Network fully connected: " + 
         fullyConnected);
      
      // Print components
      System.out.println("Network components:");
      for (int i = 0; i < n; i++) {
         System.out.println("Computer " + i + 
            " is in component " + uf.find(i));
      }
   }
   
   /**
    * Test 3: Dynamic Connectivity
    */
   public static void testDynamicConnectivity() {
      int n = 5;
      UnionFind uf = new UnionFind(n);
      
      System.out.println("Initial components: " + 
         uf.getCount());
      
      // Add connections sequentially
      int[][] connections = {
         {0, 1}, {2, 3}, {0, 4}, {3, 4}
      };
      
      for (int i = 0; i < connections.length; i++) {
         int x = connections[i][0];
         int y = connections[i][1];
         
         boolean newConnection = uf.union(x, y);
         System.out.println("Connected " + x + " and " + y + 
            ": New connection = " + newConnection);
         System.out.println("Components count: " + 
            uf.getCount());
         
         // Print connectivity status
         System.out.println("Current connectivity status:");
         for (int j = 0; j < n; j++) {
            for (int k = j + 1; k < n; k++) {
               System.out.println(j + " and " + k + 
                  " connected: " + uf.isConnected(j, k));
            }
         }
         System.out.println();
      }
   }
   
   /**
    * Main method to run tests
    */
   public static void main(String[] args) {
      System.out.println("=== Friend Circles Test ===");
      testFriendCircles();
      
      System.out.println("\n=== Network Connectivity Test ===");
      testNetworkConnectivity();
      
      System.out.println("\n=== Dynamic Connectivity Test ===");
      testDynamicConnectivity();
   }
}