def find_two_single_numbers(nums):
    # Get XOR of all numbers
    xor_all = 0
    for num in nums:
        xor_all ^= num
        
    # Find a bit where the two unique numbers differ
    # (rightmost set bit)
    diff_bit = xor_all & -xor_all
    
    # Separate numbers into two groups based on the diff bit
    num1 = 0
    for num in nums:
        if num & diff_bit:
            num1 ^= num
            
    # The other number is XOR of num1 and xor_all
    num2 = xor_all ^ num1
    
    return [num1, num2]