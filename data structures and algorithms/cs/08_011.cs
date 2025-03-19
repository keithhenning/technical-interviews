using System;
using System.Collections.Generic;

public class Fibonacci {
    // Recursive with memoization
    public static int FibonacciMemo(int n, Dictionary<int, int> memo) {
        if (n == 0) return 0;
        if (n == 1) return 1;
        
        if (!memo.ContainsKey(n)) {
            memo[n] = FibonacciMemo(n - 1, memo) + FibonacciMemo(n - 2, memo);
        }
        
        return memo[n];
    }
    
    // Wrapper method
    public static int Fibonacci(int n) {
        return FibonacciMemo(n, new Dictionary<int, int>());
    }
    
    // Iterative version (more efficient)
    public static int FibonacciIterative(int n) {
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
    
    public static void Main(string[] args) {
        Console.WriteLine(Fibonacci(6));           // 8
        Console.WriteLine(Fibonacci(10));          // 55
        Console.WriteLine(FibonacciIterative(6));  // 8
        Console.WriteLine(FibonacciIterative(10)); // 55
    }
}