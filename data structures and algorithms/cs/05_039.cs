using System;
using System.Collections.Generic;

public class Graph
{
    private Dictionary<object, List<object>> graph;
    
    public Graph()
    {
        this.graph = new Dictionary<object, List<object>>();
    }
    
    public void AddVertex(object vertex)
    {
        if (!this.graph.ContainsKey(vertex))
        {
            this.graph[vertex] = new List<object>();
        }
    }
    
    public void AddEdge(object v1, object v2)
    {
        if (!this.graph.ContainsKey(v1))
        {
            AddVertex(v1);
        }
        if (!this.graph.ContainsKey(v2))
        {
            AddVertex(v2);
        }
        this.graph[v1].Add(v2);
    }
    
    public void RemoveNode(object node)
    {
        if (!this.graph.ContainsKey(node))
        {
            return;
        }
        
        foreach (object friend in this.graph[node])
        {
            this.graph[friend].Remove(node);
        }
        
        this.graph.Remove(node);
    }
    
    public void BFS(object start)
    {
        HashSet<object> visited = new HashSet<object>();
        Queue<object> queue = new Queue<object>();
        
        queue.Enqueue(start);
        visited.Add(start);
        
        while (queue.Count > 0)
        {
            object vertex = queue.Dequeue();
            Console.Write($"{vertex} ");
            
            foreach (object neighbor in this.graph[vertex])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}
