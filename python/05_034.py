def add_edge(self, v1, v2):
    if v1 not in self.graph:
        self.add_vertex(v1)
    if v2 not in self.graph:
        self.add_vertex(v2)
    self.graph[v1].append(v2)