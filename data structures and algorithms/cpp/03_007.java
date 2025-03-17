public class Fibonacci {
    public static int fibonacci(int n) {  // O(2ⁿ)
        if (n <= 1) {
            return n;
        }
        return fibonacci(n-1) + fibonacci(n-2);
    }
    
    public static void main(String[] args) {
        // Example usage
        int n = 10;
        System.out.println("Fibonacci(" + n + ") = " + fibonacci(n));
    }
}