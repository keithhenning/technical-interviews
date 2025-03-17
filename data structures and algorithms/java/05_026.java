import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public class Node {
        public Object data;
        public Node next;
        
        public Node(Object data) {
            this.data = data;
            this.next = null;
        }
    }
    
    public class TextEditorHistory {
        private LinkedList changes;
        private Node current;
        
        public TextEditorHistory() {
            this.changes = new LinkedList();
            this.current = null;
        }
        
        public void addChange(String textState) {
            Node newNode = new Node(textState);
            if (this.current == null) {
                this.changes.head = newNode;
            } else {
                newNode.next = this.current.next;
                this.current.next = newNode;
            }
            this.current = newNode;
        }
    }
}