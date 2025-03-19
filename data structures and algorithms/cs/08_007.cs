using System.Collections.Generic;

public class SlidingWindowExtremaProduct {
    public int[] FindExtremaProducts(int[] prices, int k) {
        int n = prices.Length;
        
        if (n == 0 || k == 0 || k > n) {
            return new int[0];
        }
        
        int[] result = new int[n - k + 1];
        Deque<int> maxDeque = new Deque<int>();
        Deque<int> minDeque = new Deque<int>();
        
        // Process the first window
        for (int i = 0; i < k; i++) {
            // Remove smaller elements from maxDeque
            while (maxDeque.Count > 0 && prices[i] >= prices[maxDeque.Last()]) {
                maxDeque.RemoveLast();
            }
            maxDeque.AddLast(i);
            
            // Remove larger elements from minDeque
            while (minDeque.Count > 0 && prices[i] <= prices[minDeque.Last()]) {
                minDeque.RemoveLast();
            }
            minDeque.AddLast(i);
        }
        
        // Calculate product for the first window
        result[0] = prices[maxDeque.First()] * prices[minDeque.First()];
        
        // Process the rest of the windows
        for (int i = k; i < n; i++) {
            // Remove elements outside the current window
            while (maxDeque.Count > 0 && maxDeque.First() <= i - k) {
                maxDeque.RemoveFirst();
            }
            while (minDeque.Count > 0 && minDeque.First() <= i - k) {
                minDeque.RemoveFirst();
            }
            
            // Remove smaller elements from maxDeque
            while (maxDeque.Count > 0 && prices[i] >= prices[maxDeque.Last()]) {
                maxDeque.RemoveLast();
            }
            maxDeque.AddLast(i);
            
            // Remove larger elements from minDeque
            while (minDeque.Count > 0 && prices[i] <= prices[minDeque.Last()]) {
                minDeque.RemoveLast();
            }
            minDeque.AddLast(i);
            
            // Calculate product for the current window
            result[i - k + 1] = prices[maxDeque.First()] * prices[minDeque.First()];
        }
        
        return result;
    }
}