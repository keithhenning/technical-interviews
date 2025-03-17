import java.util.HashMap;
import java.util.Map;

/**
 * Scheduler for tasks with cooldown period
 */
public class TaskScheduler {
   /**
    * Calculate minimum time to finish all tasks with cooldown
    * 
    * @param tasks Array of tasks to be executed
    * @param n Cooldown period between identical tasks
    * @return Minimum time required to complete all tasks
    */
   public static int minTimeToFinishTasks(char[] tasks, int n) {
      if (tasks == null || tasks.length == 0) {
         return 0;
      }
      
      // Count frequency of each task
      Map<Character, Integer> taskCounts = new HashMap<>();
      for (char task : tasks) {
         taskCounts.put(task, 
                     taskCounts.getOrDefault(task, 0) + 1);
      }
      
      // Find task with maximum frequency
      int maxFreq = 0;
      for (int count : taskCounts.values()) {
         maxFreq = Math.max(maxFreq, count);
      }
      
      // Count tasks with maximum frequency
      int maxFreqTasks = 0;
      for (int count : taskCounts.values()) {
         if (count == maxFreq) {
            maxFreqTasks++;
         }
      }
      
      // Calculate using the formula:
      // (maxFreq-1) * (n+1) + maxFreqTasks
      int result = (maxFreq - 1) * (n + 1) + maxFreqTasks;
      
      // Result should be at least the total task count
      return Math.max(result, tasks.length);
   }
   
   /**
    * Test the scheduler with example inputs
    */
   public static void main(String[] args) {
      // Example 1
      char[] tasks1 = {'A', 'A', 'B', 'C', 'A', 'B'};
      int n1 = 2;
      System.out.println("Example 1 result: " + 
            minTimeToFinishTasks(tasks1, n1));  // Output: 7
      
      // Example 2
      char[] tasks2 = {'A', 'A', 'A', 'B', 'B', 'B'};
      int n2 = 2;
      System.out.println("Example 2 result: " + 
            minTimeToFinishTasks(tasks2, n2));  // Output: 8
   }
}