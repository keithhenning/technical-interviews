using System;
using System.Collections.Generic;

public class MainClass {
    public static void Main(string[] args) {
        // Main method code goes here
    }
    
    public class TaskScheduler {
        private Deque<string> taskQueue;
        
        public TaskScheduler() {
            this.taskQueue = new Deque<string>();
        }
        
        public void AddTask(string task) {
            this.taskQueue.AddLast(task);
        }
        
        public void ProcessTasks() {
            while (this.taskQueue.Count > 0) {
                string currentTask = this.taskQueue.RemoveFirst();
                // Process task here
            }
        }
    }
}
