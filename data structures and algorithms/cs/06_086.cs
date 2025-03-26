using System;

public class UnionFindDemo
{
   /**
    * Main method to demonstrate UnionFind
    */
   public static void Main(string[] args)
   {
      // Initialize with 10 elements (0-9)
      UnionFind uf = new UnionFind(10);

      // Connect elements
      uf.Union(0, 1);
      uf.Union(1, 2);
      uf.Union(3, 4);

      // Check connectivity
      Console.WriteLine(uf.IsConnected(0, 2) ? "true" : "false");
      // true
      Console.WriteLine(uf.IsConnected(0, 4) ? "true" : "false");
      // false

      // Number of disjoint sets
      Console.WriteLine(uf.GetCount()); // 7
   }
}