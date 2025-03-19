using System;
using System.Collections.Generic;

public class FibonacciVariations {
    // Without memoization - exponential time complexity
    public static long FibSlow(int n) {
        if (n <= 1) {
            return n;
        }
        return FibSlow(n-1) + FibSlow(n-2);
    }

    // With memoization using a Dictionary
    public static long FibMemo(int n, Dictionary<int, long> memo = null) {
        if (memo == null) {
            memo = new Dictionary<int, long>();
        }
        
        if (memo.ContainsKey(n)) {
            return memo[n];
        }
        
        if (n <= 1) {
            return n;
        }
        
        memo[n] = FibMemo(n-1, memo) + FibMemo(n-2, memo);
        return memo[n];
    }
    
    // Using memoization with a static cache
    private static Dictionary<int, long> cache = new Dictionary<int, long>();
    
    public static long FibCache(int n) {
        if (cache.ContainsKey(n)) {
            return cache[n];
        }
        
        if (n <= 1) {
            return n;
        }
        
        cache[n] = FibCache(n-1) + FibCache(n-2);
        return cache[n];
    }
    
    public static void Main(string[] args) {
        // This calculates quickly!
        Console.WriteLine(FibCache(40));
    }
}