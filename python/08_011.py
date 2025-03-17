# Recursive with memoization

def fibonacci_memo(n, memo={}):
    if n == 0:
        return 0
    if n == 1:
        return 1
    
    if n not in memo:
        memo[n] = (fibonacci_memo(n - 1, memo) + 
                   fibonacci_memo(n - 2, memo))
    
    return memo[n]

# Iterative version (more efficient)
def fibonacci_iterative(n):
    if n == 0:
        return 0
    if n == 1:
        return 1
    
    prev, curr = 0, 1
    
    for _ in range(2, n + 1):
        next_val = prev + curr
        prev = curr
        curr = next_val
    
    return curr

# Example usage
print(fibonacci_memo(6))        # 8
print(fibonacci_memo(10))       # 55
print(fibonacci_iterative(6))   # 8
print(fibonacci_iterative(10))  # 55