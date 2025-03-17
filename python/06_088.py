def main():
  # Initialize with 10 elements
  uf = UnionFind(10)
  
  # Connect elements
  uf.union(0, 1)
  uf.union(1, 2)
  uf.union(3, 4)
  
  # Check connections
  print(uf.is_connected(0, 2))  # True
  print(uf.is_connected(0, 4))  # False
  
  # Disjoint sets count
  print(uf.count)  # 7

if __name__ == "__main__":
  main()