#include <iostream>
#include <unordered_map>

// Recursive with memoization
int fibonacciMemo(int n, std::unordered_map<int, int>& memo) {
    if (n == 0) return 0;
    if (n == 1) return 1;
    
    if (memo.find(n) == memo.end()) {
        memo[n] = fibonacciMemo(n - 1, memo) + 
                 fibonacciMemo(n - 2, memo);
    }
    
    return memo[n];
}

// Wrapper function
int fibonacci(int n) {
    std::unordered_map<int, int> memo;
    return fibonacciMemo(n, memo);
}

// Iterative version (more efficient)
int fibonacciIterative(int n) {
    if (n == 0) return 0;
    if (n == 1) return 1;
    
    int prev = 0;
    int curr = 1;
    
    for (int i = 2; i <= n; i++) {
        int next = prev + curr;
        prev = curr;
        curr = next;
    }
    
    return curr;
}

int main() {
    std::cout << fibonacci(6) << std::endl;           // 8
    std::cout << fibonacci(10) << std::endl;          // 55
    std::cout << fibonacciIterative(6) << std::endl;  // 8
    std::cout << fibonacciIterative(10) << std::endl; // 55
    return 0;
}