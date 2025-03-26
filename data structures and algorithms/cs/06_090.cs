public static int FriendCircles(int[][] M)
{
   int n = M.Length;
   UnionFind uf = new UnionFind(n);

   for (int i = 0; i < n; i++)
   {
      for (int j = i + 1; j < n; j++)
      {
         if (M[i][j] == 1)
         {
            uf.Union(i, j);
         }
      }
   }

   return uf.GetCount();
}