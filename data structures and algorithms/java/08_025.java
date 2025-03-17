import java.util.*;

/**
 * Represents a task with scheduling attributes
 */
class Task {
   String id;
   int priority;
   int resourceNeeds;
   int deadline;
   
   Task(String id, int priority, int resourceNeeds, 
         int deadline) {
      this.id = id;
      this.priority = priority;
      this.resourceNeeds = resourceNeeds;
      this.deadline = deadline;
   }
}

/**
 * Schedules tasks based on priority and deadline
 */
public class AdaptiveResourceScheduler {
   /**
    * Schedule tasks in optimal order
    */
   public static List<String> scheduleTasks(List<Task> tasks) {
      // Sort by priority (high to low) then deadline (early first)
      Collections.sort(tasks, (a, b) -> {
         if (a.priority != b.priority) {
            return b.priority - a.priority; // Descending priority
         }
         return a.deadline - b.deadline; // Ascending deadline
      });
      
      // Store execution order
      List<String> result = new ArrayList<>();
      
      // Track current time
      int currentTime = 0;
      
      // Process each task in sorted order
      for (Task task : tasks) {
         result.add(task.id);
         currentTime += task.resourceNeeds;
      }
      
      return result;
   }
   
   /**
    * Test the scheduling algorithm
    */
   public static void main(String[] args) {
      List<Task> tasks = Arrays.asList(
         new Task("T1", 3, 5, 10),
         new Task("T2", 5, 3, 5),
         new Task("T3", 2, 2, 7),
         new Task("T4", 5, 1, 3)
      );
      
      List<String> schedule = scheduleTasks(tasks);
      System.out.println("Task execution order: " + schedule);
      // Expected output: [T4, T2, T1, T3]
   }
}