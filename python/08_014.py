# Definition for singly-linked list

class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

def reverse_list(head):
    prev = None
    current = head
    
    while current:
        # Save the next node
        next_node = current.next
        
        # Reverse the pointer
        current.next = prev
        
        # Move pointers forward
        prev = current
        current = next_node
    
    # prev is the new head
    return prev

# Helper function to create a linked list from an array
def create_linked_list(arr):
    if not arr:
        return None
    
    head = ListNode(arr[0])
    current = head
    
    for i in range(1, len(arr)):
        current.next = ListNode(arr[i])
        current = current.next
    
    return head

# Helper function to convert linked list to array
def linked_list_to_array(head):
    result = []
    current = head
    
    while current:
        result.append(current.val)
        current = current.next
    
    return result

# Example usage
list_head = create_linked_list([1, 2, 3, 4, 5])
reversed_head = reverse_list(list_head)
print(linked_list_to_array(reversed_head))  # [5, 4, 3, 2, 1]