using System;

class BoatNode
{
   public int Id { get; }
   public bool MaintenanceNeeded { get; }
   public BoatNode Next { get; set; }

   public BoatNode(int id, bool maintenanceNeeded)
   {
      Id = id;
      MaintenanceNeeded = maintenanceNeeded;
      Next = null;
   }
}

public class Solution
{
   public BoatNode ReorderFleet(BoatNode head)
   {
      if (head == null || head.Next == null)
      {
         return head;
      }

      var maintenanceDummy = new BoatNode(0, false);
      var noMaintenanceDummy = new BoatNode(0, false);

      var maintenanceTail = maintenanceDummy;
      var noMaintenanceTail = noMaintenanceDummy;

      BoatNode current = head;
      while (current != null)
      {
         BoatNode nextBoat = current.Next;
         current.Next = null;  // Detach the node

         if (current.MaintenanceNeeded)
         {
            maintenanceTail.Next = current;
            maintenanceTail = current;
         }
         else
         {
            noMaintenanceTail.Next = current;
            noMaintenanceTail = current;
         }

         current = nextBoat;
      }

      maintenanceTail.Next = noMaintenanceDummy.Next;

      return maintenanceDummy.Next;
   }
}
