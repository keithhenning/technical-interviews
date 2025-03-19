using System;
using System.Collections.Generic;

public static List<int[]> KruskalMST(int n, int[][] edges) {
    // Sort edges by weight
    Array.Sort(edges, (a, b) => a[2].CompareTo(b[2]));

    UnionFind uf = new UnionFind(n);
    List<int[]> mst = new List<int[]>();

    foreach (int[] edge in edges) {
        int u = edge[0];
        int v = edge[1];
        int weight = edge[2];

        if (uf.Union(u, v)) {
            mst.Add(new int[] { u, v, weight });
        }

        // Early termination when we have n-1 edges
        if (mst.Count == n - 1) {
            break;
        }
    }

    return mst;
}