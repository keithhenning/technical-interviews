class ListNode:

    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

def interleave_lists(lists):
    if not lists:
        return None
    
    # Remove any empty lists
    lists = [lst for lst in lists if lst]
    if not lists:
        return None
    
    dummy = ListNode(0)
    tail = dummy
    
    while lists:
        # Process one node from each list in round-robin fashion
        for i in range(len(lists)):
            # Append current node to result
            tail.next = lists[i]
            tail = tail.next
            
            # Move to next node in current list
            lists[i] = lists[i].next
        
        # Remove any lists that became empty
        lists = [lst for lst in lists if lst]
    
    return dummy.next