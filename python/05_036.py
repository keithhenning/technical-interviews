class Graph:
    def __init__(self):
        self.adj_list = {}  # Our friendship list!
        
    def remove_node(self, node):
        # Get this person's friends before removing them
        if node not in self.adj_list:
            return
            
        # Tell all their friends they're leaving
        for friend in self.adj_list[node]:
            self.adj_list[friend].remove(node)
            
        # Remove their friend list entirely
        del self.adj_list[node]