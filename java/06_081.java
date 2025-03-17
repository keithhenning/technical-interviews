import java.util.Arrays;
import java.util.Stack;

public class MonotonicStack {
    public static int[] nextGreaterElement(int[] nums) {
        int n = nums.length;
        int[] result = new int[n];
        Arrays.fill(result, -1);  // Initialize with -1
        
        Stack<Integer> stack = new Stack<>();
        
        for (int i = 0; i < n; i++) {
            // Maintain monotonic decreasing property of the stack
            while (!stack.isEmpty() && 
                   nums[i] > nums[stack.peek()]) {
                int popped = stack.pop();
                result[popped] = nums[i];
            }
            
            stack.push(i);
        }
        
        return result;
    }
    
    public static void main(String[] args) {
        int[] nums = {4, 5, 2, 10, 8};
        int[] result = nextGreaterElement(nums);
        System.out.println(Arrays.toString(result));  
        // Output: [5, 10, 10, -1, -1]
    }
}