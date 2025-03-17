# Inside the UnionFind class, replace rank with size
def __init__(self, n):
    self.parent = list(range(n))
    self.size = [1] * n  # Each set initially has size 1
    self.count = n

def union(self, x, y):
    root_x = self.find(x)
    root_y = self.find(y)
    
    if root_x == root_y:
        return False
    
    # Attach smaller tree to the root of larger tree
    if self.size[root_x] < self.size[root_y]:
        self.parent[root_x] = root_y
        self.size[root_y] += self.size[root_x]
    else:
        self.parent[root_y] = root_x
        self.size[root_x] += self.size[root_y]
        
    self.count -= 1
    return True