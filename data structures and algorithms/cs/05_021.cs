using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

public class MainClass {
    public static void Main(string[] args) {
        // Main method code goes here
    }
    
    public void QueueImplementations() {
        // When high performance matters
        Deque<string> highPerformanceQueue = new LinkedList<string>();  // Use this!
        
        // When thread safety matters
        ConcurrentQueue<string> threadSafeQueue = new ConcurrentQueue<string>();  // Use this!
    }
}
