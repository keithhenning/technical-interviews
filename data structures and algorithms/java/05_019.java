import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;
import java.util.concurrent.*;

public class Main {
  public static void main(String[] args) {
     // Main method code goes here
  }
  
  public void queueExamples() {
     // Using Deque (preferred for performance)
     Deque<String> queue = new ArrayDeque<>();
     // Enqueue items
     queue.add("first");
     queue.add("second");
     // Dequeue (returns "first")
     String firstItem = queue.pollFirst();

     // Using Queue for thread-safe operations
     Queue<String> threadSafeQueue = 
        new LinkedBlockingQueue<>();
     // Enqueue items
     threadSafeQueue.offer("first");
     threadSafeQueue.offer("second");
     // Dequeue
     String firstThreadSafeItem = threadSafeQueue.poll();
     // Check if empty
     boolean isEmpty = threadSafeQueue.isEmpty();
  }
}