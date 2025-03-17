public class ArrayMutation {
    public static int[] solution(int n, int[] a) {
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
    
    public static void main(String[] args) {
        int[] a = {4, 0, 1, -2, 3};
        int n = a.length;
        int[] result = solution(n, a);
        
        // Print the result
        for (int val : result) {
            System.out.print(val + " ");
        }
        // Output: 4 5 -1 2 1
    }
}