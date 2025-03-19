public class ListNode {
    public int Val { get; set; }
    public ListNode Next { get; set; }

    public ListNode(int val) {
        Val = val;
    }
}

public class Solution {
    public ListNode PartitionList(ListNode head, int pivot) {
        if (head == null) {
            return null;
        }

        ListNode lessHead = new ListNode(0);
        ListNode greaterHead = new ListNode(0);
        ListNode less = lessHead;
        ListNode greater = greaterHead;
        ListNode current = head;

        while (current != null) {
            if (current.Val < pivot) {
                less.Next = current;
                less = less.Next;
            } else {
                greater.Next = current;
                greater = greater.Next;
            }
            current = current.Next;
        }

        greater.Next = null;
        less.Next = greaterHead.Next;
        return lessHead.Next;
    }
}