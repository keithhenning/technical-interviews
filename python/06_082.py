def build_prefix_sum(arr):
    n = len(arr)
    prefix_sum = [0] * n
    prefix_sum[0] = arr[0]
    
    for i in range(1, n):
        prefix_sum[i] = prefix_sum[i-1] + arr[i]
    
    return prefix_sum

def range_sum(prefix_sum, i, j):
    if i == 0:
        return prefix_sum[j]
    else:
        return prefix_sum[j] - prefix_sum[i-1]

# Example usage
arr = [3, 1, 4, 1, 5, 9, 2, 6]
prefix = build_prefix_sum(arr)
print(f"Original array: {arr}")
print(f"Prefix sum array: {prefix}")
print(f"Sum of elements from index 2 to 5: {range_sum(prefix, 2, 5)}")