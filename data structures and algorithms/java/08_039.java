import java.util.Stack;

public int maxProductivityZone(int[] capacities) {
    Stack<Integer> stack = new Stack<>();
    int maxArea = 0;
    int n = capacities.length;
    
    for (int i = 0; i < n; i++) {
        // Process stations with higher capacity than current
        while (!stack.isEmpty() && 
               capacities[stack.peek()] > capacities[i]) {
            int height = capacities[stack.pop()];
            int width = stack.isEmpty() ? i : i - stack.peek() - 1;
            maxArea = Math.max(maxArea, height * width);
        }
        
        stack.push(i);
    }
    
    // Process remaining stations in stack
    while (!stack.isEmpty()) {
        int height = capacities[stack.pop()];
        int width = stack.isEmpty() ? n : n - stack.peek() - 1;
        maxArea = Math.max(maxArea, height * width);
    }
    
    return maxArea;
}