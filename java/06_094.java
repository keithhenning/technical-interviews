import java.util.*;

class Edge implements Comparable<Edge> {
   int src, dest, weight;
   
   public Edge(int src, int dest, int weight) {
       this.src = src;
       this.dest = dest;
       this.weight = weight;
   }
   
   @Override
   public int compareTo(Edge other) {
       return this.weight - other.weight;
   }
}

class DisjointSet {
   int[] parent, rank;
   
   public DisjointSet(int n) {
       parent = new int[n];
       rank = new int[n];
       
       // Initialize each element as a separate set
       for (int i = 0; i < n; i++) {
           parent[i] = i;
       }
   }
   
   // Find with path compression
   public int find(int x) {
       if (parent[x] != x) {
           parent[x] = find(parent[x]);
       }
       return parent[x];
   }
   
   // Union by rank
   public boolean union(int x, int y) {
       int rootX = find(x);
       int rootY = find(y);
       
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
   public static List<Edge> kruskal(List<Edge> edges, int vertices) {
       // Sort edges by weight
       Collections.sort(edges);
       
       // Initialize disjoint set
       DisjointSet ds = new DisjointSet(vertices);
       
       List<Edge> mst = new ArrayList<>();
       int mstWeight = 0;
       
       // Process edges in order of increasing weight
       for (Edge edge : edges) {
           // If including this edge doesn't create a cycle
           if (ds.union(edge.src, edge.dest)) {
               mst.add(edge);
               mstWeight += edge.weight;
               
               // Stop when we have V-1 edges
               if (mst.size() == vertices - 1) {
                   break;
               }
           }
       }
       
       System.out.println("Total MST weight: " + mstWeight);
       return mst;
   }
   
   public static void main(String[] args) {
       int vertices = 6;
       List<Edge> edges = new ArrayList<>();
       
       // Add edges: (src, dest, weight)
       edges.add(new Edge(0, 1, 4));
       edges.add(new Edge(0, 2, 3));
       edges.add(new Edge(1, 2, 1));
       edges.add(new Edge(1, 3, 2));
       edges.add(new Edge(2, 3, 4));
       edges.add(new Edge(2, 4, 3));
       edges.add(new Edge(3, 4, 2));
       edges.add(new Edge(3, 5, 1));
       edges.add(new Edge(4, 5, 3));
       
       List<Edge> mst = kruskal(edges, vertices);
       
       System.out.println("Edges in the MST:");
       for (Edge edge : mst) {
           System.out.println(edge.src + " -- " + edge.dest + 
               " == " + edge.weight);
       }
   }
}