class Graph:
    def remove_node(self, node):
        # First attempt - not very efficient!
        for current_node in self.nodes:
            for edge in current_node.edges:
                if edge.connects_to(node):
                    current_node.edges.remove(edge)
        self.nodes.remove(node)