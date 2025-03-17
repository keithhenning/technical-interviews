def array_mutation(n, a):
    b = [0] * n
    
    for i in range(n):
        # Left neighbor (or 0 if out of bounds)
        left = a[i-1] if i > 0 else 0
        
        # Current element
        current = a[i]
        
        # Right neighbor (or 0 if out of bounds)
        right = a[i+1] if i < n-1 else 0
        
        # Sum all three values
        b[i] = left + current + right
        
    return b

# Example
a = [4, 0, 1, -2, 3]
n = len(a)
print(array_mutation(n, a))  # [4, 5, -1, 2, 1]