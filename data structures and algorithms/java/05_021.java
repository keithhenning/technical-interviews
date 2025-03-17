import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public void queueImplementations() {
        // When high performance matters
        Deque<String> highPerformanceQueue = new ArrayDeque<>();  // Use this!
        
        // When thread safety matters
        Queue<String> threadSafeQueue = new LinkedBlockingQueue<>();  // Use this!
    }
}