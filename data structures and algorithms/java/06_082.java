public static int[] dailyTemperatures(int[] temperatures) {
   int n = temperatures.length;
   int[] result = new int[n];
   Stack<Integer> stack = new Stack<>();
   
   for (int i = 0; i < n; i++) {
       while (!stack.isEmpty() && 
              temperatures[i] > temperatures[stack.peek()]) {
           int prevDay = stack.pop();
           result[prevDay] = i - prevDay;
       }
       stack.push(i);
   }
   
   return result;
}

// Example
public static void main(String[] args) {
   int[] temps = {73, 74, 75, 71, 69, 72, 76, 73};
   int[] result = dailyTemperatures(temps);
   System.out.println(Arrays.toString(result));
   // Output: [1, 1, 4, 2, 1, 1, 0, 0]
}