import java.util.*;

class Graph {
   private int V;
   private List<List<Integer>> adj;
   
   public Graph(int vertices) {
       V = vertices;
       adj = new ArrayList<>(V);
       for (int i = 0; i < V; i++) {
           adj.add(new ArrayList<>());
       }
   }
   
   public void addEdge(int u, int v) {
       adj.get(u).add(v);
   }
   
   // Kahn's Algorithm
   public List<Integer> topologicalSortKahn() {
       int[] inDegree = new int[V];
       for (int i = 0; i < V; i++) {
           for (int neighbor : adj.get(i)) {
               inDegree[neighbor]++;
           }
       }
       
       Queue<Integer> queue = new LinkedList<>();
       for (int i = 0; i < V; i++) {
           if (inDegree[i] == 0) {
               queue.add(i);
           }
       }
       
       List<Integer> result = new ArrayList<>();
       while (!queue.isEmpty()) {
           int vertex = queue.poll();
           result.add(vertex);
           
           for (int neighbor : adj.get(vertex)) {
               inDegree[neighbor]--;
               if (inDegree[neighbor] == 0) {
                   queue.add(neighbor);
               }
           }
       }
       
       return result.size() == V ? result : new ArrayList<>();
   }
   
   // DFS-based Algorithm
   public List<Integer> topologicalSortDFS() {
       boolean[] visited = new boolean[V];
       LinkedList<Integer> stack = new LinkedList<>();
       
       for (int i = 0; i < V; i++) {
           if (!visited[i]) {
               dfsUtil(i, visited, stack);
           }
       }
       
       return stack;
   }
   
   private void dfsUtil(int v, boolean[] visited, 
                       LinkedList<Integer> stack) {
       visited[v] = true;
       
       for (int neighbor : adj.get(v)) {
           if (!visited[neighbor]) {
               dfsUtil(neighbor, visited, stack);
           }
       }
       
       stack.addFirst(v);
   }
}