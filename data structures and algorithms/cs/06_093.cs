using System;
using System.Collections.Generic;

public class PrimsAlgorithm {
    /**
     * Edge in a weighted graph
     */
    public class Edge : IComparable<Edge> {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }

        public Edge(int source, int destination, int weight) {
            Source = source;
            Destination = destination;
            Weight = weight;
        }

        public int CompareTo(Edge other) {
            return Weight - other.Weight;
        }
    }

    /**
     * Find Minimum Spanning Tree using Prim's algorithm
     */
    public static List<Edge> PrimsAlgorithm(List<List<Edge>> graph) {
        int vertices = graph.Count;
        bool[] inMST = new bool[vertices];
        List<Edge> mst = new List<Edge>();

        // Priority queue for edges by weight
        PriorityQueue<Edge> pq = new PriorityQueue<Edge>();

        // Start with vertex 0
        int startVertex = 0;
        inMST[startVertex] = true;

        // Add all edges from start vertex
        foreach (Edge edge in graph[startVertex]) {
            pq.Enqueue(edge);
        }

        // Build MST with V-1 edges
        while (pq.Count > 0 && mst.Count < vertices - 1) {
            // Get minimum weight edge
            Edge minEdge = pq.Dequeue();

            // Check if destination already in MST
            if (!inMST[minEdge.Destination]) {
                // Add to MST
                mst.Add(minEdge);
                int newVertex = minEdge.Destination;
                inMST[newVertex] = true;

                // Add edges from newly added vertex
                foreach (Edge edge in graph[newVertex]) {
                    // Only if not creating cycle
                    if (!inMST[edge.Destination]) {
                        pq.Enqueue(edge);
                    }
                }
            }
        }

        return mst;
    }

    /**
     * Test Prim's algorithm
     */
    public static void Main(string[] args) {
        // Create graph with 4 vertices
        int vertices = 4;
        List<List<Edge>> graph = new List<List<Edge>>(vertices);

        for (int i = 0; i < vertices; i++) {
            graph.Add(new List<Edge>());
        }

        // Add edges (undirected graph)
        // A(0) - B(1) weight 2
        graph[0].Add(new Edge(0, 1, 2));
        graph[1].Add(new Edge(1, 0, 2));

        // A(0) - D(3) weight 1
        graph[0].Add(new Edge(0, 3, 1));
        graph[3].Add(new Edge(3, 0, 1));

        // B(1) - D(3) weight 2
        graph[1].Add(new Edge(1, 3, 2));
        graph[3].Add(new Edge(3, 1, 2));

        // B(1) - C(2) weight 3
        graph[1].Add(new Edge(1, 2, 3));
        graph[2].Add(new Edge(2, 1, 3));

        // C(2) - D(3) weight 4
        graph[2].Add(new Edge(2, 3, 4));
        graph[3].Add(new Edge(3, 2, 4));

        // Run Prim's algorithm
        List<Edge> mst = PrimsAlgorithm(graph);

        // Print result
        Console.WriteLine("Minimum Spanning Tree edges:");
        foreach (Edge edge in mst) {
            Console.WriteLine(edge.Source + " -- " + edge.Destination + " : " + edge.Weight);
        }
    }
}