class PlayerNode {
   String name;
   double battingAverage;
   PlayerNode next;
   
   public PlayerNode(String name, 
         double battingAverage) {
      this.name = name;
      this.battingAverage = battingAverage;
      this.next = null;
   }
}

public class Solution {
   public String rotateLineupAndFindBest(
         PlayerNode head, int k, int m) {
      // Handle edge cases
      if (head == null || head.next == head || 
          k == 0) {
         return findBestBatter(head, m);
      }
      
      // Find kth node
      PlayerNode current = head;
      for (int i = 0; i < k - 1; i++) {
         current = current.next;
      }
      
      // New head
      PlayerNode newHead = current.next;
      
      // Find last node
      PlayerNode last = newHead;
      while (last.next != head) {
         last = last.next;
      }
      
      // Rotate circular list
      current.next = head;
      last.next = newHead;
      
      // Find best batter
      return findBestBatter(newHead, m);
   }
   
   // Find best batter in window
   private String findBestBatter(PlayerNode head, 
         int m) {
      if (head == null) {
         return null;
      }
      
      PlayerNode bestPlayer = head;
      PlayerNode current = head;
      
      // Check first m players
      for (int i = 0; i < m - 1; i++) {
         current = current.next;
         if (current.battingAverage > 
             bestPlayer.battingAverage) {
            bestPlayer = current;
         }
         
         // Handle circular boundary
         if (current == head) {
            break;
         }
      }
      
      return bestPlayer.name;
   }
}