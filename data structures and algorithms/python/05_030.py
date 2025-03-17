class UndirectedGraph:
    def __init__(self):
        self.graph = {}
    
    def add_relationship(self, node1, node2):
        # Ensure both nodes exist in the graph
        if node1 not in self.graph:
            self.graph[node1] = []
        if node2 not in self.graph:
            self.graph[node2] = []
            
        # Add bidirectional relationship
        self.graph[node1].append(node2)
        self.graph[node2].append(node1)