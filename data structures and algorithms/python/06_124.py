def solution(n, a):
    return [(0 if i-1 < 0 else a[i-1]) + a[i] + (0 if i+1 >= n else a[i+1]) for i in range(n)]