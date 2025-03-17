class DirectedGraph:
    def __init__(self):
        self.graph = {}
    
    def add_relationship(self, from_node, to_node):
        if from_node not in self.graph:
            self.graph[from_node] = []
        self.graph[from_node].append(to_node)