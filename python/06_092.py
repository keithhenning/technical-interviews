def friend_circles(M):
    n = len(M)
    uf = UnionFind(n)
    
    for i in range(n):
        for j in range(i+1, n):
            if M[i][j] == 1:
                uf.union(i, j)
                
    return uf.count