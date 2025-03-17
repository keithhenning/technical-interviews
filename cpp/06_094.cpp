#include <iostream>
#include <bitset>
#include <vector>

// Display binary representation of an integer
template <size_t N>
void printBinary(int num) {
   std::bitset<N> bits(num);
   std::cout << bits << std::endl;
}

// Demonstrate various binary operations
void binaryOperationsDemo() {
   int a = 25;  // 11001 in binary
   int b = 13;  // 01101 in binary
   
   // Basic operations
   std::cout << "a = " << a << " (binary: " 
             << std::bitset<5>(a) << ")" << std::endl;
   std::cout << "b = " << b << " (binary: " 
             << std::bitset<5>(b) << ")" << std::endl;
   std::cout << "a & b = " << (a & b) << " (binary: " 
             << std::bitset<5>(a & b) << ")" << std::endl;
   std::cout << "a | b = " << (a | b) << " (binary: " 
             << std::bitset<5>(a | b) << ")" << std::endl;
   std::cout << "a ^ b = " << (a ^ b) << " (binary: " 
             << std::bitset<5>(a ^ b) << ")" << std::endl;
   std::cout << "~a = " << (~a) << " (truncated binary: " 
             << std::bitset<8>(~a & 0xFF) << ")" 
             << std::endl;
   std::cout << "a << 2 = " << (a << 2) << " (binary: " 
             << std::bitset<7>(a << 2) << ")" << std::endl;
   std::cout << "a >> 2 = " << (a >> 2) << " (binary: " 
             << std::bitset<3>(a >> 2) << ")" << std::endl;
}

// Count the number of 1s in binary representation of n
int countSetBits(int n) {
   int count = 0;
   while (n) {
      count += n & 1;  // Check if LSB is 1
      n >>= 1;         // Right shift by 1
   }
   return count;
}

// Alternative way using C++'s built-in function
int countSetBitsBuiltin(int n) {
   return __builtin_popcount(n);  // GCC specific
}

// Check if n is a power of 2
bool isPowerOfTwo(int n) {
   return n > 0 && (n & (n - 1)) == 0;
}

// Set the bit at given position to 1
int setBit(int n, int position) {
   return n | (1 << position);
}

// Clear the bit at given position to 0
int clearBit(int n, int position) {
   return n & ~(1 << position);
}

// Toggle the bit at given position
int toggleBit(int n, int position) {
   return n ^ (1 << position);
}

// Check if bit at given position is 1
bool isBitSet(int n, int position) {
   return (n & (1 << position)) != 0;
}

// Find the single number in an array where all other 
// numbers appear twice
int findSingleNumber(const std::vector<int>& nums) {
   int result = 0;
   for (int num : nums) {
      result ^= num;  // XOR of a number with itself is 0
   }
   return result;
}

int main() {
   binaryOperationsDemo();
   
   // Test other functions
   std::cout << "\nCount of set bits in 25: " 
             << countSetBits(25) << std::endl;
   std::cout << "Is 16 a power of 2? " 
             << (isPowerOfTwo(16) ? "Yes" : "No") 
             << std::endl;
   std::cout << "Is 18 a power of 2? " 
             << (isPowerOfTwo(18) ? "Yes" : "No") 
             << std::endl;
   
   std::vector<int> nums = {4, 1, 2, 1, 2};
   std::cout << "Single number in [4,1,2,1,2]: " 
             << findSingleNumber(nums) << std::endl;
   
   return 0;
}