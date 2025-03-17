public class FibonacciVariations {
    // Without memoization - exponential time complexity
    public static long fibSlow(int n) {
        if (n <= 1) {
            return n;
        }
        return fibSlow(n-1) + fibSlow(n-2);
    }

    // With memoization using a HashMap
    public static long fibMemo(int n, Map<Integer, Long> memo) {
        if (memo == null) {
            memo = new HashMap<>();
        }
        
        if (memo.containsKey(n)) {
            return memo.get(n);
        }
        
        if (n <= 1) {
            return n;
        }
        
        memo.put(n, fibMemo(n-1, memo) + fibMemo(n-2, memo));
        return memo.get(n);
    }
    
    // Using memoization with a static cache
    private static Map<Integer, Long> cache = new HashMap<>();
    
    public static long fibCache(int n) {
        if (cache.containsKey(n)) {
            return cache.get(n);
        }
        
        if (n <= 1) {
            return n;
        }
        
        cache.put(n, fibCache(n-1) + fibCache(n-2));
        return cache.get(n);
    }
    
    public static void main(String[] args) {
        // This calculates quickly!
        System.out.println(fibCache(40));
    }
}