void addVertex(int vertex) {
    if (graph.find(vertex) == graph.end()) {
        graph[vertex] = std::vector<int>();
    }
}