import java.util.ArrayDeque;
import java.util.Deque;

public class SlidingWindowExtremaProduct {
    public int[] findExtremaProducts(int[] prices, int k) {
        int n = prices.length;
        
        if (n == 0 || k == 0 || k > n) {
            return new int[0];
        }
        
        int[] result = new int[n - k + 1];
        Deque<Integer> maxDeque = new ArrayDeque<>();
        Deque<Integer> minDeque = new ArrayDeque<>();
        
        // Process the first window
        for (int i = 0; i < k; i++) {
            // Remove smaller elements from maxDeque
            while (!maxDeque.isEmpty() && 
                   prices[i] >= prices[maxDeque.peekLast()]) {
                maxDeque.pollLast();
            }
            maxDeque.offerLast(i);
            
            // Remove larger elements from minDeque
            while (!minDeque.isEmpty() && 
                   prices[i] <= prices[minDeque.peekLast()]) {
                minDeque.pollLast();
            }
            minDeque.offerLast(i);
        }
        
        // Calculate product for the first window
        result[0] = prices[maxDeque.peekFirst()] * 
                    prices[minDeque.peekFirst()];
        
        // Process the rest of the windows
        for (int i = k; i < n; i++) {
            // Remove elements outside the current window
            while (!maxDeque.isEmpty() && 
                   maxDeque.peekFirst() <= i - k) {
                maxDeque.pollFirst();
            }
            while (!minDeque.isEmpty() && 
                   minDeque.peekFirst() <= i - k) {
                minDeque.pollFirst();
            }
            
            // Remove smaller elements from maxDeque
            while (!maxDeque.isEmpty() && 
                   prices[i] >= prices[maxDeque.peekLast()]) {
                maxDeque.pollLast();
            }
            maxDeque.offerLast(i);
            
            // Remove larger elements from minDeque
            while (!minDeque.isEmpty() && 
                   prices[i] <= prices[minDeque.peekLast()]) {
                minDeque.pollLast();
            }
            minDeque.offerLast(i);
            
            // Calculate product for the current window
            result[i - k + 1] = prices[maxDeque.peekFirst()] * 
                               prices[minDeque.peekFirst()];
        }
        
        return result;
    }
}