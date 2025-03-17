def find_missing_number(nums):
    n = len(nums)
    expected_sum = n * (n + 1) // 2
    actual_sum = sum(nums)
    return expected_sum - actual_sum
    
# Alternative bit manipulation approach
def find_missing_number_xor(nums):
    result = len(nums)
    for i, num in enumerate(nums):
        result ^= i ^ num
    return result