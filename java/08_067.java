class BoatNode {
    int id;
    boolean maintenanceNeeded;
    BoatNode next;
    
    public BoatNode(int id, boolean maintenanceNeeded) {
        this.id = id;
        this.maintenanceNeeded = maintenanceNeeded;
        this.next = null;
    }
}

public class Solution {
    public BoatNode reorderFleet(BoatNode head) {
        if (head == null || head.next == null) {
            return head;
        }
        
        // Create dummy heads for our two chains
        BoatNode maintenanceDummy = new BoatNode(0, false);
        BoatNode noMaintenanceDummy = new BoatNode(0, false);
        
        // Pointers to track the end of each chain
        BoatNode maintenanceTail = maintenanceDummy;
        BoatNode noMaintenanceTail = noMaintenanceDummy;
        
        // Traverse the original list
        BoatNode current = head;
        while (current != null) {
            BoatNode nextBoat = current.next;
            current.next = null;  // Detach the node
            
            if (current.maintenanceNeeded) {
                maintenanceTail.next = current;
                maintenanceTail = current;
            } else {
                noMaintenanceTail.next = current;
                noMaintenanceTail = current;
            }
            
            current = nextBoat;
        }
        
        // Connect the two chains
        maintenanceTail.next = noMaintenanceDummy.next;
        
        // Return the head of the merged chain
        return maintenanceDummy.next;
    }
}