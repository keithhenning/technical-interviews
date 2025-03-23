public static List<int[]> AstarMemoryEfficient(
    int[][] grid, int[] start, int[] goal)
{
   // Store only essential information
   Dictionary<string, int[]> parent =
       new Dictionary<string, int[]>();
   Dictionary<string, int> gScore =
       new Dictionary<string, int>();
   gScore[JsonConvert.SerializeObject(start)] = 0;

    // Use function for neighbors to avoid creating full lists
    class NeighborGenerator
{
   public IEnumerable<int[]> GetNeighbors(int[] pos)
   {
      List<int[]> neighbors = new List<int[]>();
      int[][] directions = {
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { 0, -1 },
                new int[] { -1, 0 }
            };

      foreach (int[] dir in directions)
      {
         int[] newPos = {
                    pos[0] + dir[0],
                    pos[1] + dir[1]
                };
         if (IsValid(newPos))
         {
            neighbors.Add(newPos);
         }
      }
      return neighbors;
   }

   private bool IsValid(int[] pos)
   {
      return pos[0] >= 0 &&
             pos[0] < grid.Length &&
             pos[1] >= 0 &&
             pos[1] < grid[0].Length &&
             grid[pos[0]][pos[1]] != 1;
   }
}

NeighborGenerator neighborGen =
    new NeighborGenerator();

// Rest of A* implementation...
return null;
}
