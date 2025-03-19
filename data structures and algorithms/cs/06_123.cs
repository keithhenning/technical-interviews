using System;
using System.Collections.Generic;
using System.Linq;

public class AStar
{
    private class Node : IComparable<Node>
    {
        public int[] Position { get; set; }
        public double G { get; set; }
        public double H { get; set; }
        public double F => G + H;
        public Node Parent { get; set; }

        public int CompareTo(Node other)
        {
            return F.CompareTo(other.F);
        }
    }

    public static List<int[]> FindPath(int[][] grid, int[] start, int[] goal)
    {
        var openSet = new SortedSet<Node>();
        var closedSet = new HashSet<string>();
        var startNode = new Node { Position = start };
        
        startNode.G = 0;
        startNode.H = Heuristic(start, goal);
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            var current = openSet.Min;
            openSet.Remove(current);

            if (current.Position.SequenceEqual(goal))
            {
                return ReconstructPath(current);
            }

            closedSet.Add(string.Join(",", current.Position));

            foreach (var neighbor in GetNeighbors(current.Position, grid))
            {
                if (closedSet.Contains(string.Join(",", neighbor)))
                    continue;

                var tentativeG = current.G + 1;
                var neighborNode = new Node 
                { 
                    Position = neighbor,
                    G = tentativeG,
                    H = Heuristic(neighbor, goal),
                    Parent = current
                };

                openSet.Add(neighborNode);
            }
        }

        return new List<int[]>();
    }

    private static double Heuristic(int[] a, int[] b)
    {
        return Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]);
    }

    private static List<int[]> GetNeighbors(int[] pos, int[][] grid)
    {
        var neighbors = new List<int[]>();
        int[][] dirs = new[] { new[] {0,1}, new[] {1,0}, new[] {0,-1}, new[] {-1,0} };

        foreach (var dir in dirs)
        {
            int[] newPos = new[] { pos[0] + dir[0], pos[1] + dir[1] };
            if (IsValid(newPos, grid))
                neighbors.Add(newPos);
        }
        return neighbors;
    }

    private static bool IsValid(int[] pos, int[][] grid)
    {
        return pos[0] >= 0 && pos[0] < grid.Length && 
               pos[1] >= 0 && pos[1] < grid[0].Length && 
               grid[pos[0]][pos[1]] == 0;
    }

    private static List<int[]> ReconstructPath(Node node)
    {
        var path = new List<int[]>();
        while (node != null)
        {
            path.Add(node.Position);
            node = node.Parent;
        }
        path.Reverse();
        return path;
    }
}
