public static int[] IdentifyJumpPoint(
    int[] node, int[] direction, int[][] grid)
{
   // Skip straight lines until finding a turn
   int x = node[0];
   int y = node[1];
   int dx = direction[0];
   int dy = direction[1];

   while (ValidPosition(x + dx, y + dy, grid))
   {
      x += dx;
      y += dy;

      if (HasForcedNeighbor(x, y, direction, grid))
      {
         return new int[] { x, y };
      }
   }

   return null;
}
