using System;
using System.Collections.Generic;

public class AStarSearch<T> where T : class
{
   public delegate double HeuristicDelegate(T current, T goal);
   public delegate IEnumerable<T> NeighborsDelegate(T node);

   public List<T> FindPath(
       T start,
       T goal,
       HeuristicDelegate heuristic,
       NeighborsDelegate getNeighbors)
   {
      var openSet = new SortedSet<(double f, T node)>();
      var closedSet = new HashSet<T>();
      var gScores = new Dictionary<T, double>();
      var cameFrom = new Dictionary<T, T>();

      openSet.Add((heuristic(start, goal), start));
      gScores[start] = 0;

      while (openSet.Count > 0)
      {
         var current = openSet.Min.node;
         if (current.Equals(goal))
         {
            return ReconstructPath(cameFrom, current);
         }

         openSet.Remove(openSet.Min);
         closedSet.Add(current);

         foreach (var neighbor in getNeighbors(current))
         {
            if (closedSet.Contains(neighbor))
               continue;

            var tentativeG = gScores[current] + 1;

            if (!gScores.ContainsKey(neighbor) ||
                tentativeG < gScores[neighbor])
            {
               cameFrom[neighbor] = current;
               gScores[neighbor] = tentativeG;
               var f = tentativeG + heuristic(neighbor, goal);
               openSet.Add((f, neighbor));
            }
         }
      }

      return new List<T>();
   }

   private List<T> ReconstructPath(
       Dictionary<T, T> cameFrom, T current)
   {
      var path = new List<T> { current };
      while (cameFrom.ContainsKey(current))
      {
         current = cameFrom[current];
         path.Add(current);
      }
      path.Reverse();
      return path;
   }
}
