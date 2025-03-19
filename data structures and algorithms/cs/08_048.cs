using System.Collections.Generic;

public class ListNode {
    public int Val { get; set; }
    public ListNode Next { get; set; }

    public ListNode(int val) {
        Val = val;
    }
}

public class Solution {
    public ListNode InterleaveLists(ListNode[] lists) {
        if (lists == null || lists.Length == 0) {
            return null;
        }

        var activeList = new List<ListNode>();
        foreach (var list in lists) {
            if (list != null) {
                activeList.Add(list);
            }
        }

        if (activeList.Count == 0) {
            return null;
        }

        ListNode dummy = new ListNode(0);
        ListNode tail = dummy;

        while (activeList.Count > 0) {
            int size = activeList.Count;
            for (int i = 0; i < size; i++) {
                ListNode current = activeList[0];
                activeList.RemoveAt(0);

                tail.Next = current;
                tail = tail.Next;

                if (current.Next != null) {
                    activeList.Add(current.Next);
                }
            }
        }

        return dummy.Next;
    }
}