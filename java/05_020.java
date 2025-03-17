import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public class TaskScheduler {
        private Deque<String> taskQueue;
        
        public TaskScheduler() {
            this.taskQueue = new ArrayDeque<>();
        }
        
        public void addTask(String task) {
            this.taskQueue.add(task);
        }
        
        public void processTasks() {
            while (!this.taskQueue.isEmpty()) {
                String currentTask = this.taskQueue.pollFirst();
                // Process task here
            }
        }
    }
}