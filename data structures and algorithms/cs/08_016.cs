using System;
using System.Collections.Generic;

public class DependencyResolver {
    public static List<string> ResolveDependencies(Dictionary<string, List<string>> tasks) {
        // Build adjacency list and in-degree count
        var graph = new Dictionary<string, List<string>>();
        var inDegree = new Dictionary<string, int>();

        foreach (var task in tasks.Keys) {
            graph[task] = new List<string>();
            inDegree[task] = 0;
        }

        foreach (var entry in tasks) {
            var task = entry.Key;
            var dependencies = entry.Value;

            foreach (var dep in dependencies) {
                graph[dep].Add(task);
                inDegree[task]++;
            }
        }

        // Start with tasks that have no dependencies
        var queue = new Queue<string>();
        foreach (var entry in inDegree) {
            if (entry.Value == 0) {
                queue.Enqueue(entry.Key);
            }
        }

        var result = new List<string>();

        // Process tasks level by level
        while (queue.Count > 0) {
            var current = queue.Dequeue();
            result.Add(current);

            // Reduce in-degree of dependent tasks
            foreach (var dependent in graph[current]) {
                inDegree[dependent]--;
                if (inDegree[dependent] == 0) {
                    queue.Enqueue(dependent);
                }
            }
        }

        // Check if we have a valid order (no cycles)
        if (result.Count != tasks.Count) {
            return null; // Cycle detected
        }

        return result;
    }
}