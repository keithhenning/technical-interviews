using System;
using System.Collections.Generic;

class Point {
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y) {
        X = x;
        Y = y;
    }

    public int DistanceToOrigin() {
        return X * X + Y * Y;
    }

    public override bool Equals(object obj) {
        if (this == obj) return true;
        if (!(obj is Point)) return false;
        Point other = (Point)obj;
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode() {
        return HashCode.Combine(X, Y);
    }

    public override string ToString() {
        return $"({X}, {Y})";
    }
}

class KNearestInWindow {
    private readonly int windowSize;
    private readonly int k;
    private readonly LinkedList<Point> window;
    private readonly PriorityQueue<Point> heap;

    public KNearestInWindow(int windowSize, int k) {
        this.windowSize = windowSize;
        this.k = k;
        this.window = new LinkedList<Point>();
        this.heap = new PriorityQueue<Point>((p1, p2) => p2.DistanceToOrigin().CompareTo(p1.DistanceToOrigin()));
    }

    public void AddPoint(Point point) {
        window.AddLast(point);

        if (window.Count > windowSize) {
            Point oldest = window.First.Value;
            window.RemoveFirst();

            if (heap.Contains(oldest)) {
                RebuildHeap();
            }
        }

        if (heap.Count < k) {
            heap.Enqueue(point);
        } else if (point.DistanceToOrigin() < heap.Peek().DistanceToOrigin()) {
            heap.Dequeue();
            heap.Enqueue(point);
        }
    }

    private void RebuildHeap() {
        heap.Clear();
        var points = new List<Point>(window);
        points.Sort((p1, p2) => p1.DistanceToOrigin().CompareTo(p2.DistanceToOrigin()));
        for (int i = 0; i < Math.Min(k, points.Count); i++) {
            heap.Enqueue(points[i]);
        }
    }

    public List<Point> GetKNearest() {
        var result = new List<Point>(heap);
        result.Sort((p1, p2) => p1.DistanceToOrigin().CompareTo(p2.DistanceToOrigin()));
        return result;
    }

    public static void Main(string[] args) {
        int[][] pointsArray = {
            new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 0, 1 }, new int[] { 5, 2 },
            new int[] { 2, 0 }, new int[] { 1, 5 }, new int[] { 3, 1 }
        };
        int windowSize = 5;
        int k = 3;

        var knn = new KNearestInWindow(windowSize, k);
        foreach (var p in pointsArray) {
            knn.AddPoint(new Point(p[0], p[1]));
        }

        var result = knn.GetKNearest();
        Console.WriteLine("K nearest points: " + string.Join(", ", result));
    }
}