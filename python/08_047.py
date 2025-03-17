class ListNode:

    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

def partition_list(head, pivot):
    if not head:
        return None
        
    # Create dummy heads for both partitions
    less_head = ListNode(0)
    greater_head = ListNode(0)
    
    less = less_head
    greater = greater_head
    
    # Traverse the original list
    current = head
    while current:
        if current.val < pivot:
            less.next = current
            less = less.next
        else:
            greater.next = current
            greater = greater.next
        
        current = current.next
    
    # Connect the two lists
    greater.next = None
    less.next = greater_head.next
    
    return less_head.next