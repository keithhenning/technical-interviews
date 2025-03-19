public class ArrayMutation {
    public static int[] Solution(int n, int[] a) {
        int[] b = new int[n];
        
        for (int i = 0; i < n; i++) {
            // Left neighbor (or 0 if out of bounds)
            int left = (i > 0) ? a[i-1] : 0;
            
            // Current element
            int current = a[i];
            
            // Right neighbor (or 0 if out of bounds)
            int right = (i < n-1) ? a[i+1] : 0;
            
            // Sum all three values
            b[i] = left + current + right;
        }
        
        return b;
    }
    
    public static void Main(string[] args) {
        int[] a = {4, 0, 1, -2, 3};
        int n = a.Length;
        int[] result = Solution(n, a);
        
        // Print the result
        foreach (int val in result) {
            Console.Write(val + " ");
        }
        // Output: 4 5 -1 2 1
    }
}