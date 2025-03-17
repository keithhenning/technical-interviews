import java.util.HashMap;
import java.util.Map;

public class Fibonacci {
    // Recursive with memoization
    public static int fibonacciMemo(int n, Map<Integer, Integer> memo) {
        if (n == 0) return 0;
        if (n == 1) return 1;
        
        if (!memo.containsKey(n)) {
            memo.put(n, fibonacciMemo(n - 1, memo) + 
                       fibonacciMemo(n - 2, memo));
        }
        
        return memo.get(n);
    }
    
    // Wrapper method
    public static int fibonacci(int n) {
        return fibonacciMemo(n, new HashMap<>());
    }
    
    // Iterative version (more efficient)
    public static int fibonacciIterative(int n) {
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
    
    public static void main(String[] args) {
        System.out.println(fibonacci(6));           // 8
        System.out.println(fibonacci(10));          // 55
        System.out.println(fibonacciIterative(6));  // 8
        System.out.println(fibonacciIterative(10)); // 55
    }
}