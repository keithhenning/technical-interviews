def fibonacci(n):  # O(2ⁿ)
    if n <= 1:
        return n
    return fibonacci(n-1) + fibonacci(n-2)