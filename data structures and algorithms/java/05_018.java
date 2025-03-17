import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
   public static void main(String[] args) {
      // Main method code goes here
   }
   
   // Static inner class for better access
   public static class Stack<T> {
      // Initialize stack with an empty list
      private ArrayList<T> stack;
      
      public Stack() {
         this.stack = new ArrayList<>();
      }
      
      // Java uses methods not properties
      public int getLength() {
         return stack.size();
      }
      
      public T push(T item) {
         // Add item to the top of stack
         this.stack.add(item);
         return item;
      }
      
      public T pop() {
         // Remove and return the top item
         if (!this.isEmpty()) {
            return this.stack.remove(this.stack.size() - 1);
         }
         // Better to throw exception than return null
         throw new EmptyStackException();
      }
      
      public T peek() {
         // Look at the top item without removing
         if (!this.isEmpty()) {
            return this.stack.get(this.stack.size() - 1);
         }
         // Better to throw exception than return null
         throw new EmptyStackException();
      }
      
      public boolean isEmpty() {
         // Check if stack is empty
         return this.getLength() == 0;
      }
   }

   // Test method
   public void testStack() {
      Stack<String> album = new Stack<>();
      album.push("album 1");  
      album.push("album 2"); 
      album.push("album 3");
      
      System.out.println("Top album is: " + album.peek());
      album.pop();
      System.out.println("Now the top album is: " + 
         album.peek());
      System.out.println("Total albums in stack: " + 
         album.getLength());
   }
}