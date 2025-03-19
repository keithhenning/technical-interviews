using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

public class MainClass {
    public static void Main(string[] args) {
        // Main method code goes here
    }
    
    public void QueueExamples() {
        // Using Deque (preferred for performance)
        Deque<string> queue = new Deque<string>();
        // Enqueue items
        queue.AddLast("first");
        queue.AddLast("second");
        // Dequeue (returns "first")
        string firstItem = queue.RemoveFirst();

        // Using Queue for thread-safe operations
        ConcurrentQueue<string> threadSafeQueue = new ConcurrentQueue<string>();
        // Enqueue items
        threadSafeQueue.Enqueue("first");
        threadSafeQueue.Enqueue("second");
        // Dequeue
        threadSafeQueue.TryDequeue(out string firstThreadSafeItem);
        // Check if empty
        bool isEmpty = threadSafeQueue.IsEmpty;
    }
}
