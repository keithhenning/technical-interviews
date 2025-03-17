def kruskal_mst(n, edges):
    # Sort edges by weight
    edges.sort(key=lambda x: x[2])
    
    uf = UnionFind(n)
    mst = []
    
    for u, v, weight in edges:
        if uf.union(u, v):
            mst.append((u, v, weight))
        
        # Early termination when we have n-1 edges
        if len(mst) == n - 1:
            break
            
    return mst