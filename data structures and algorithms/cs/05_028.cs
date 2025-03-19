using System;

public class MainClass {
    public static void Main(string[] args) {
        // Main method code goes here
    }
    
    public bool HasCycle(Node head) {
        Node slow = head;
        Node fast = head;
        while (fast != null && fast.Next != null) {
            slow = slow.Next;
            fast = fast.Next.Next;
            if (slow == fast) {
                return true;
            }
        }
        return false;
    }
    
    public class Node {
        public int Value;
        public Node Next;
        
        public Node(int value) {
            this.Value = value;
            this.Next = null;
        }
    }
}
