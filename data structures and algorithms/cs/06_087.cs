public class UnionFind
{
   private int[] parent;
   private int[] size;
   private int count;

   public UnionFind(int n)
   {
      parent = new int[n];
      size = new int[n];  // Each set initially has size 1
      count = n;

      for (int i = 0; i < n; i++)
      {
         parent[i] = i;
         size[i] = 1;
      }
   }

   public bool Union(int x, int y)
   {
      int rootX = Find(x);
      int rootY = Find(y);

      if (rootX == rootY)
      {
         return false;
      }

      // Attach smaller tree to the root of larger tree
      if (size[rootX] < size[rootY])
      {
         parent[rootX] = rootY;
         size[rootY] += size[rootX];
      }
      else
      {
         parent[rootY] = rootX;
         size[rootX] += size[rootY];
      }

      count--;
      return true;
   }
}