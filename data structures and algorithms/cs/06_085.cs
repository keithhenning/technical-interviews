using System;
using System.Collections.Generic;

public class UnionFind
{
   private int[] parent;
   private int[] rank;
   private int count;

   /**
    * Initialize UnionFind with n elements
    */
   public UnionFind(int n)
   {
      parent = new int[n];
      rank = new int[n];
      count = n;

      // Each element starts in its own set
      for (int i = 0; i < n; i++)
      {
         parent[i] = i;
         rank[i] = 0;
      }
   }

   /**
    * Find the representative of element x
    */
   public int Find(int x)
   {
      if (parent[x] != x)
      {
         // Path compression optimization
         parent[x] = Find(parent[x]);
      }
      return parent[x];
   }

   /**
    * Merge sets containing elements x and y
    */
   public bool Union(int x, int y)
   {
      int rootX = Find(x);
      int rootY = Find(y);

      // Already in same set
      if (rootX == rootY)
      {
         return false;
      }

      // Union by rank optimization
      if (rank[rootX] < rank[rootY])
      {
         parent[rootX] = rootY;
      }
      else if (rank[rootX] > rank[rootY])
      {
         parent[rootY] = rootX;
      }
      else
      {
         parent[rootY] = rootX;
         rank[rootX]++;
      }

      count--;
      return true;
   }

   /**
    * Check if elements x and y are in same set
    */
   public bool IsConnected(int x, int y)
   {
      return Find(x) == Find(y);
   }

   /**
    * Get number of disjoint sets
    */
   public int GetCount()
   {
      return count;
   }

   /**
    * Test 1: Friend Circles
    */
   public static void TestFriendCircles()
   {
      // Friendship matrix
      int[][] friendships = {
            new int[] {1, 1, 0, 0},
            new int[] {1, 1, 1, 0},
            new int[] {0, 1, 1, 0},
            new int[] {0, 0, 0, 1}
        };

      int n = friendships.Length;
      UnionFind uf = new UnionFind(n);

      // Union friends
      for (int i = 0; i < n; i++)
      {
         for (int j = i + 1; j < n; j++)
         {
            if (friendships[i][j] == 1)
            {
               uf.Union(i, j);
            }
         }
      }

      // Count circles
      int circles = uf.GetCount();
      Console.WriteLine("Friend Circles: " + circles);

      // Print group memberships
      for (int i = 0; i < n; i++)
      {
         Console.WriteLine("Student " + i +
         " belongs to group " + uf.Find(i));
      }
   }

   /**
    * Test 2: Network Connectivity
    */
   public static void TestNetworkConnectivity()
   {
      int n = 6; // 6 computers
      int[][] connections = {
            new int[] {0, 1},
            new int[] {1, 2},
            new int[] {3, 4}
        };

      UnionFind uf = new UnionFind(n);

      // Process connections
      for (int i = 0; i < connections.Length; i++)
      {
         uf.Union(connections[i][0], connections[i][1]);
      }

      // Check full connectivity
      bool fullyConnected = uf.GetCount() == 1;
      Console.WriteLine("Network fully connected: " + fullyConnected);

      // Print components
      Console.WriteLine("Network components:");
      for (int i = 0; i < n; i++)
      {
         Console.WriteLine("Computer " + i +
         " is in component " + uf.Find(i));
      }
   }

   /**
    * Test 3: Dynamic Connectivity
    */
   public static void TestDynamicConnectivity()
   {
      int n = 5;
      UnionFind uf = new UnionFind(n);

      Console.WriteLine("Initial components: " + uf.GetCount());

      // Add connections sequentially
      int[][] connections = {
            new int[] {0, 1}, new int[] {2, 3},
            new int[] {0, 4}, new int[] {3, 4}
        };

      for (int i = 0; i < connections.Length; i++)
      {
         int x = connections[i][0];
         int y = connections[i][1];

         bool newConnection = uf.Union(x, y);
         Console.WriteLine("Connected " + x + " and " + y +
         ": New connection = " + newConnection);
         Console.WriteLine("Components count: " + uf.GetCount());

         // Print connectivity status
         Console.WriteLine("Current connectivity status:");
         for (int j = 0; j < n; j++)
         {
            for (int k = j + 1; k < n; k++)
            {
               Console.WriteLine(j + " and " + k +
               " connected: " + uf.IsConnected(j, k));
            }
         }
         Console.WriteLine();
      }
   }

   /**
    * Main method to run tests
    */
   public static void Main(string[] args)
   {
      Console.WriteLine("=== Friend Circles Test ===");
      TestFriendCircles();

      Console.WriteLine("\n=== Network Connectivity Test ===");
      TestNetworkConnectivity();

      Console.WriteLine("\n=== Dynamic Connectivity Test ===");
      TestDynamicConnectivity();
   }
}