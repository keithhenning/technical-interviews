/**
* Bidirectional A* search from start and goal
*/
public static List<int[]> BidirectionalAstar(
    int[][] grid, int[] start, int[] goal)
{
   // Initialize forward search front (from start)
   Dictionary<string, int> forwardFront =
       new Dictionary<string, int>();
   forwardFront[JsonConvert.SerializeObject(start)] = 0;
   Dictionary<string, int[]> forwardParents =
       new Dictionary<string, int[]>();

   // Initialize backward search front (from goal)
   Dictionary<string, int> backwardFront =
       new Dictionary<string, int>();
   backwardFront[JsonConvert.SerializeObject(goal)] = 0;
   Dictionary<string, int[]> backwardParents =
       new Dictionary<string, int[]>();

   // Search until fronts meet or are exhausted
   while (forwardFront.Count > 0 && backwardFront.Count > 0)
   {
      // Expand the smaller front first for efficiency
      string current;
      if (forwardFront.Count < backwardFront.Count)
      {
         current = ExpandFront(forwardFront, forwardParents,
             grid, goal, true);
      }
      else
      {
         current = ExpandFront(backwardFront, backwardParents,
             grid, start, false);
      }

      // Check if fronts have met at current position
      if (forwardFront.ContainsKey(current) &&
          backwardFront.ContainsKey(current))
      {
         return ReconstructPath(current, forwardParents,
             backwardParents);
      }
   }

   // No path found
   return null;
}
