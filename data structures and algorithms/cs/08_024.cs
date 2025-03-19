using System;
using System.Collections.Generic;

public class DynamicMazeFloodFill {
    public class Position {
        public int X { get; set; }
        public int Y { get; set; }
        public int Time { get; set; }

        public Position(int x, int y, int time) {
            X = x;
            Y = y;
            Time = time;
        }
    }

    public static int FloodFillTime(int[][] maze, int startX, int startY, int targetX, int targetY) {
        int rows = maze.Length;
        int cols = maze[0].Length;
        bool[][] visited = new bool[rows][];
        for (int i = 0; i < rows; i++) {
            visited[i] = new bool[cols];
        }

        var queue = new Queue<Position>();
        queue.Enqueue(new Position(startX, startY, 0));
        visited[startX][startY] = true;

        int[][] directions = { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };

        while (queue.Count > 0) {
            var current = queue.Dequeue();

            if (current.X == targetX && current.Y == targetY) {
                return current.Time;
            }

            foreach (var dir in directions) {
                int nx = current.X + dir[0];
                int ny = current.Y + dir[1];

                if (nx >= 0 && nx < rows && ny >= 0 && ny < cols && !visited[nx][ny] && maze[nx][ny] == 0) {
                    visited[nx][ny] = true;
                    queue.Enqueue(new Position(nx, ny, current.Time + 1));
                }
            }
        }

        return -1;
    }

    public static void Main(string[] args) {
        int[][] maze = {
            new int[] { 0, 0, 0, 0 },
            new int[] { 1, 1, 0, 1 },
            new int[] { 0, 2, 0, 0 },
            new int[] { 0, 1, 1, 0 }
        };

        int result = FloodFillTime(maze, 2, 1, 0, 0);
        Console.WriteLine("Shortest path length: " + result);
    }
}