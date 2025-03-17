def is_power_of_four(n):
   # Check if positive and power of 2
   if n <= 0 or (n & (n-1)) != 0:
      return False
   
   # Check set bit at even positions
   # 0x55555555 is 01010101...01 in binary
   return (n & 0x55555555) != 0