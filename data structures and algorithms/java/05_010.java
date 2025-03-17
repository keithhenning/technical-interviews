import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
  public static void main(String[] args) {
     // Main method code goes here
  }
  
  public void stackExample() {
     // Create an empty stack
     Stack<String> stack = new Stack<>();
     // Push items onto stack
     stack.push("first");
     stack.push("second");
     // Pop - returns and removes "second"
     String lastItem = stack.pop();
     // Peek at top item without removing
     String topItem = stack.peek();
     // Check if empty
     boolean isEmpty = stack.isEmpty();
  }
}