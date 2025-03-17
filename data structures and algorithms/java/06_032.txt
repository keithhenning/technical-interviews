public static int[] identifyJumpPoint(int[] node, int[] direction, int[][] grid) {
   // Skip straight lines until finding a turn
   int x = node[0];
   int y = node[1];
   int dx = direction[0];
   int dy = direction[1];
   
   while (validPosition(x + dx, y + dy, grid)) {
       x += dx;
       y += dy;
       
       if (hasForcedNeighbor(x, y, direction, grid)) {
           return new int[]{x, y};
       }
   }
   
   return null;
}