class ListNode {
    int val;
    ListNode next;
    
    ListNode(int val) {
        this.val = val;
    }
}

public class Solution {
    public ListNode partitionList(ListNode head, int pivot) {
        if (head == null) {
            return null;
        }
        
        // Create dummy heads for both partitions
        ListNode lessHead = new ListNode(0);
        ListNode greaterHead = new ListNode(0);
        
        ListNode less = lessHead;
        ListNode greater = greaterHead;
        
        // Traverse the original list
        ListNode current = head;
        while (current != null) {
            if (current.val < pivot) {
                less.next = current;
                less = less.next;
            } else {
                greater.next = current;
                greater = greater.next;
            }
            
            current = current.next;
        }
        
        // Connect the two lists
        greater.next = null;
        less.next = greaterHead.next;
        
        return lessHead.next;
    }
}