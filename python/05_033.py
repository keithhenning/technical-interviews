def add_vertex(self, vertex):
    if vertex not in self.graph:
        self.graph[vertex] = []