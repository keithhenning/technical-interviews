using System.Collections.Generic;

public class UnionFind {
    // ...existing code...

    public List<int> GetComponent(int x) {
        int root = Find(x);
        List<int> component = new List<int>();

        for (int i = 0; i < parent.Length; i++) {
            if (Find(i) == root) {
                component.Add(i);
            }
        }

        return component;
    }
}