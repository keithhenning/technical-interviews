import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
   public static void main(String[] args) {
      // Main method code goes here
   }
   
   /**
    * A node in a linked list with data and next reference
    */
   public static class Node {
      // The value stored in the node
      public Object data;
      
      // Reference to the next node (null if none)
      public Node next;
      
      /**
       * Initialize a new Node with data
       */
      public Node(Object data) {
         this.data = data;
         this.next = null;
      }
   }

   /**
    * A singly linked list data structure
    */
   public static class LinkedList {
      // Reference to the first node
      private Node head;
      
      // Reference to the last node
      private Node tail;
      
      // Number of nodes in the list
      private int length;
      
      /**
       * Initialize an empty linked list
       */
      public LinkedList() {
         this.head = null;
         this.tail = null;
         this.length = 0;
      }
      
      /**
       * Add a new node to the end of the list
       */
      public LinkedList push(Object data) {
         // Create a new node
         Node newNode = new Node(data);
         
         // Case 1: Empty List
         if (this.head == null) {
            this.head = newNode;
            this.tail = newNode;
         } 
         // Case 2: List has nodes
         else {
            this.tail.next = newNode;
            this.tail = newNode;
         }
             
         this.length++;
         return this;
      }
      
      /**
       * Print the list elements from head to tail
       */
      public void display() {
         // Start at the head node
         Node current = this.head;
         while (current != null) {
            System.out.print(current.data + " -> ");
            current = current.next;
         }
         System.out.println("null");
      }
   }

   // Example usage
   public void linkedListExample() {
      LinkedList list = new LinkedList();
      list.push(1);
      list.push(2);
      list.push(3);
      list.display(); // 1 -> 2 -> 3 -> null
   }
}