using System;
using System.Collections.Generic;

public class MainClass {
    public static void Main(string[] args) {
        // Main method code goes here
    }
    
    public class Node {
        public object data;
        public Node next;
        
        public Node(object data) {
            this.data = data;
            this.next = null;
        }
    }
    
    public class TextEditorHistory {
        private LinkedList<Node> changes;
        private Node current;
        
        public TextEditorHistory() {
            this.changes = new LinkedList<Node>();
            this.current = null;
        }
        
        public void AddChange(string textState) {
            Node newNode = new Node(textState);
            if (this.current == null) {
                this.changes.AddFirst(newNode);
            } else {
                newNode.next = this.current.next;
                this.current.next = newNode;
            }
            this.current = newNode;
        }

        public void PrintHistory() {
            Node current = changes.First;
            while (current != null) {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }
    }
}
