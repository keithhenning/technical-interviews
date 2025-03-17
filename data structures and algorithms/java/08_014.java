public class ReverseLinkedList {
    // Definition for singly-linked list
    public static class ListNode {
        int val;
        ListNode next;
        
        ListNode(int x) {
            val = x;
        }
    }
    
    public static ListNode reverseList(ListNode head) {
        ListNode prev = null;
        ListNode current = head;
        
        while (current != null) {
            // Save the next node
            ListNode next = current.next;
            
            // Reverse the pointer
            current.next = prev;
            
            // Move pointers forward
            prev = current;
            current = next;
        }
        
        // prev is the new head
        return prev;
    }
    
    // Helper function to create a linked list from an array
    public static ListNode createLinkedList(int[] arr) {
        if (arr == null || arr.length == 0) {
            return null;
        }
        
        ListNode head = new ListNode(arr[0]);
        ListNode current = head;
        
        for (int i = 1; i < arr.length; i++) {
            current.next = new ListNode(arr[i]);
            current = current.next;
        }
        
        return head;
    }
    
    // Helper function to convert linked list to array for display
    public static int[] linkedListToArray(ListNode head) {
        // First, count the number of nodes
        int count = 0;
        ListNode current = head;
        while (current != null) {
            count++;
            current = current.next;
        }
        
        int[] result = new int[count];
        current = head;
        int i = 0;
        
        while (current != null) {
            result[i++] = current.val;
            current = current.next;
        }
        
        return result;
    }
    
    // Helper to print array
    public static void printArray(int[] arr) {
        System.out.print("[");
        for (int i = 0; i < arr.length; i++) {
            System.out.print(arr[i]);
            if (i < arr.length - 1) {
                System.out.print(", ");
            }
        }
        System.out.println("]");
    }
    
    public static void main(String[] args) {
        ListNode list = createLinkedList(new int[]{1, 2, 3, 4, 5});
        ListNode reversedList = reverseList(list);
        printArray(linkedListToArray(reversedList));  
        // [5, 4, 3, 2, 1]
    }
}