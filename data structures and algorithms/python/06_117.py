def recursive_func(n, depth=0, memo={}):
    indent = "  " * depth
    print(f"{indent}Computing f({n})")
    if n in memo:
        print(f"{indent}Found in cache: {memo[n]}")
        return memo[n]
    # Rest of function...