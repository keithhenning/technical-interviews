using System;
using System.Collections.Generic;

public class TaskScheduler {
    public static int MinTimeToFinishTasks(char[] tasks, int n) {
        if (tasks == null || tasks.Length == 0) {
            return 0;
        }

        var taskCounts = new Dictionary<char, int>();
        foreach (var task in tasks) {
            if (!taskCounts.ContainsKey(task)) {
                taskCounts[task] = 0;
            }
            taskCounts[task]++;
        }

        int maxFreq = 0;
        foreach (var count in taskCounts.Values) {
            maxFreq = Math.Max(maxFreq, count);
        }

        int maxFreqTasks = 0;
        foreach (var count in taskCounts.Values) {
            if (count == maxFreq) {
                maxFreqTasks++;
            }
        }

        int result = (maxFreq - 1) * (n + 1) + maxFreqTasks;
        return Math.Max(result, tasks.Length);
    }

    public static void Main(string[] args) {
        char[] tasks1 = { 'A', 'A', 'B', 'C', 'A', 'B' };
        int n1 = 2;
        Console.WriteLine("Example 1 result: " + MinTimeToFinishTasks(tasks1, n1));  // Output: 7

        char[] tasks2 = { 'A', 'A', 'A', 'B', 'B', 'B' };
        int n2 = 2;
        Console.WriteLine("Example 2 result: " + MinTimeToFinishTasks(tasks2, n2));  // Output: 8
    }
}