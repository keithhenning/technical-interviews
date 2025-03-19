using System.Collections.Generic;

public class TemperatureAnalyzer {
    public static int[] DaysUntilWarmer(int[] temperatures) {
        int n = temperatures.Length;
        int[] result = new int[n];
        var stack = new Stack<int>();

        for (int i = 0; i < n; i++) {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()]) {
                int prev = stack.Pop();
                result[prev] = i - prev;
            }
            stack.Push(i);
        }

        return result;
    }
}