class BoatNode:

    def __init__(self, id, maintenanceNeeded, next=None):
        self.id = id
        self.maintenanceNeeded = maintenanceNeeded
        self.next = next

def reorderFleet(head):
    if not head or not head.next:
        return head
    
    # Create dummy heads for our two chains
    maintenance_dummy = BoatNode(0, False)
    no_maintenance_dummy = BoatNode(0, False)
    
    # Pointers to track the end of each chain
    maintenance_tail = maintenance_dummy
    no_maintenance_tail = no_maintenance_dummy
    
    # Traverse the original list
    current = head
    while current:
        next_boat = current.next
        current.next = None  # Detach the node
        
        if current.maintenanceNeeded:
            maintenance_tail.next = current
            maintenance_tail = current
        else:
            no_maintenance_tail.next = current
            no_maintenance_tail = current
        
        current = next_boat
    
    # Connect the two chains
    maintenance_tail.next = no_maintenance_dummy.next
    
    # Return the head of the merged chain
    return maintenance_dummy.next