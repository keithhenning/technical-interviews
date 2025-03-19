using System;
using System.Collections.Generic;

public class Edge : IComparable<Edge> {
    public int Src { get; set; }
    public int Dest { get; set; }
    public int Weight { get; set; }

    public Edge(int src, int dest, int weight) {
        Src = src;
        Dest = dest;
        Weight = weight;
    }

    public int CompareTo(Edge other) {
        return Weight - other.Weight;
    }
}

public class DisjointSet {
    private int[] parent, rank;

    public DisjointSet(int n) {
        parent = new int[n];
        rank = new int[n];

        // Initialize each element as a separate set
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }
    }

    // Find with path compression
    public int Find(int x) {
        if (parent[x] != x) {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }

    // Union by rank
    public bool Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY) {
            return false;
        }

        if (rank[rootX] < rank[rootY]) {
            parent[rootX] = rootY;
        } else if (rank[rootX] > rank[rootY]) {
            parent[rootY] = rootX;
        } else {
            parent[rootY] = rootX;
            rank[rootX]++;
        }

        return true;
    }
}

public class KruskalAlgorithm {
    public static List<Edge> Kruskal(List<Edge> edges, int vertices) {
        // Sort edges by weight
        edges.Sort();

        // Initialize disjoint set
        DisjointSet ds = new DisjointSet(vertices);

        List<Edge> mst = new List<Edge>();
        int mstWeight = 0;

        // Process edges in order of increasing weight
        foreach (Edge edge in edges) {
            // If including this edge doesn't create a cycle
            if (ds.Union(edge.Src, edge.Dest)) {
                mst.Add(edge);
                mstWeight += edge.Weight;

                // Stop when we have V-1 edges
                if (mst.Count == vertices - 1) {
                    break;
                }
            }
        }

        Console.WriteLine("Total MST weight: " + mstWeight);
        return mst;
    }

    public static void Main(string[] args) {
        int vertices = 6;
        List<Edge> edges = new List<Edge>();

        // Add edges: (src, dest, weight)
        edges.Add(new Edge(0, 1, 4));
        edges.Add(new Edge(0, 2, 3));
        edges.Add(new Edge(1, 2, 1));
        edges.Add(new Edge(1, 3, 2));
        edges.Add(new Edge(2, 3, 4));
        edges.Add(new Edge(2, 4, 3));
        edges.Add(new Edge(3, 4, 2));
        edges.Add(new Edge(3, 5, 1));
        edges.Add(new Edge(4, 5, 3));

        List<Edge> mst = Kruskal(edges, vertices);

        Console.WriteLine("Edges in the MST:");
        foreach (Edge edge in mst) {
            Console.WriteLine(edge.Src + " -- " + edge.Dest + " == " + edge.Weight);
        }
    }
}