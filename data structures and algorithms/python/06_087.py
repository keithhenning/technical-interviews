class UnionFind:
   def __init__(self, n):
      # Initial parent, each is own set
      self.parent = list(range(n))
      # Rank for balancing tree
      self.rank = [0] * n
      # Count of disjoint sets
      self.count = n
   
   def find(self, x):
      # Path compression
      if self.parent[x] != x:
         self.parent[x] = self.find(self.parent[x])
      return self.parent[x]
   
   def union(self, x, y):
      # Find set roots
      root_x = self.find(x)
      root_y = self.find(y)
      
      # Already in same set
      if root_x == root_y:
         return False
      
      # Union by rank
      if self.rank[root_x] < self.rank[root_y]:
         self.parent[root_x] = root_y
      elif self.rank[root_x] > self.rank[root_y]:
         self.parent[root_y] = root_x
      else:
         # Equal ranks
         self.parent[root_y] = root_x
         self.rank[root_x] += 1
      
      # Decrease set count
      self.count -= 1
      return True
   
   def is_connected(self, x, y):
      # Check same set
      return self.find(x) == self.find(y)