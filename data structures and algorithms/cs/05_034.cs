using System;
using System.Collections.Generic;
using System.Linq;

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

    public bool HasVertex(object vertex)
    {
        return this.graph.ContainsKey(vertex);
    }

    public IEnumerable<object> GetAdjacent(object vertex)
    {
        return HasVertex(vertex) ? this.graph[vertex] : Enumerable.Empty<object>();
    }
}
