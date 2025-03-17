class ListNode {
    int val;
    ListNode next;
    
    ListNode(int val) {
        this.val = val;
    }
}

public class Solution {
    public ListNode interleaveLists(ListNode[] lists) {
        if (lists == null || lists.length == 0) {
            return null;
        }
        
        // Create a new list to store non-empty lists
        List<ListNode> activeList = new ArrayList<>();
        for (ListNode list : lists) {
            if (list != null) {
                activeList.add(list);
            }
        }
        
        if (activeList.isEmpty()) {
            return null;
        }
        
        ListNode dummy = new ListNode(0);
        ListNode tail = dummy;
        
        while (!activeList.isEmpty()) {
            // Process one node from each list
            int size = activeList.size();
            for (int i = 0; i < size; i++) {
                ListNode current = activeList.remove(0);
                
                // Append current node to result
                tail.next = current;
                tail = tail.next;
                
                // Move to next node in current list
                if (current.next != null) {
                    activeList.add(current.next);
                }
            }
        }
        
        return dummy.next;
    }
}