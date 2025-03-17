def binary_operations_demo():
   # Demonstrate binary operations with
   # sample numbers
   a = 25  # 11001 in binary
   b = 13  # 01101 in binary
   
   # Print decimal and binary
   # representations
   print(f"a = {a} (binary: {bin(a)[2:].zfill(5)})")
   print(f"b = {b} (binary: {bin(b)[2:].zfill(5)})")
   
   # Bitwise AND operation
   print(f"a & b = {a & b} (binary: {bin(a & b)[2:].zfill(5)})")
   
   # Bitwise OR operation
   print(f"a | b = {a | b} (binary: {bin(a | b)[2:].zfill(5)})")
   
   # Bitwise XOR operation
   print(f"a ^ b = {a ^ b} (binary: {bin(a ^ b)[2:].zfill(5)})")
   
   # Bitwise NOT operation
   print(f"~a = {~a} (truncated binary: {bin(~a & 0xFF)[2:].zfill(8)})")
   
   # Left shift operation
   print(f"a << 2 = {a << 2} (binary: {bin(a << 2)[2:].zfill(7)})")
   
   # Right shift operation
   print(f"a >> 2 = {a >> 2} (binary: {bin(a >> 2)[2:].zfill(3)})")


def count_set_bits(n):
   """
   Count the number of 1s in binary
   representation of n
   """
   count = 0
   while n:
      # Check least significant bit
      count += n & 1
      # Right shift by 1
      n >>= 1
   return count


def is_power_of_two(n):
   """
   Check if n is a power of 2
   """
   # Detect single bit set
   return n > 0 and (n & (n-1)) == 0


def set_bit(n, position):
   """Set the bit at given position to 1"""
   return n | (1 << position)


def clear_bit(n, position):
   """Clear the bit at given position to 0"""
   return n & ~(1 << position)


def toggle_bit(n, position):
   """Toggle the bit at given position"""
   return n ^ (1 << position)


def is_bit_set(n, position):
   """
   Check if bit at given position is 1
   """
   return (n & (1 << position)) != 0


def find_single_number(nums):
   """
   Find single number in array where
   all others appear twice
   """
   result = 0
   for num in nums:
      # XOR of number with itself is 0
      result ^= num
   return result