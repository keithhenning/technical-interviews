def recursive_func(m, n, memo={}):
    if (m, n) in memo:
        return memo[(m, n)]
    # Calculate result
    memo[(m, n)] = result
    return result