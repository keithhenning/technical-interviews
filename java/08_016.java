import java.util.*;

public class DependencyResolver {
    public static List<String> resolveDependencies(
                              Map<String, List<String>> tasks) {
        // Build adjacency list and in-degree count
        Map<String, List<String>> graph = new HashMap<>();
        Map<String, Integer> inDegree = new HashMap<>();
        
        for (String task : tasks.keySet()) {
            graph.put(task, new ArrayList<>());
            inDegree.put(task, 0);
        }
        
        for (Map.Entry<String, List<String>> entry : 
             tasks.entrySet()) {
            String task = entry.getKey();
            List<String> dependencies = entry.getValue();
            
            for (String dep : dependencies) {
                graph.get(dep).add(task);
                inDegree.put(task, inDegree.get(task) + 1);
            }
        }
        
        // Start with tasks that have no dependencies
        Queue<String> queue = new LinkedList<>();
        for (Map.Entry<String, Integer> entry : 
             inDegree.entrySet()) {
            if (entry.getValue() == 0) {
                queue.add(entry.getKey());
            }
        }
        
        List<String> result = new ArrayList<>();
        
        // Process tasks level by level
        while (!queue.isEmpty()) {
            String current = queue.poll();
            result.add(current);
            
            // Reduce in-degree of dependent tasks
            for (String dependent : graph.get(current)) {
                inDegree.put(dependent, 
                           inDegree.get(dependent) - 1);
                if (inDegree.get(dependent) == 0) {
                    queue.add(dependent);
                }
            }
        }
        
        // Check if we have a valid order (no cycles)
        if (result.size() != tasks.size()) {
            return null; // Cycle detected
        }
        
        return result;
    }
}