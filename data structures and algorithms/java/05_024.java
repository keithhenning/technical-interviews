import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public void remove(Object target, Node head) {
        Node current = head;
        Node prev = null;
        while (current != null) {
            if (current.data.equals(target)) {
                prev.next = current.next;
                break;
            }
            prev = current;
            current = current.next;
        }
    }
}