import java.util.*;

public class Solution {
   public int maxWeddingHappiness(
         int[][] relationships, 
         int tables, 
         int seatsPerTable) {
      int n = relationships.length;
      if (n > tables * seatsPerTable) {
         return -1;  // Not enough seats
      }
      
      // Initial random seating
      List<Integer> guests = new ArrayList<>();
      for (int i = 0; i < n; i++) {
         guests.add(i);
      }
      Collections.shuffle(guests);
      
      // Distribute guests
      List<List<Integer>> seating = 
         new ArrayList<>();
      for (int t = 0; t < tables; t++) {
         int startIdx = t * seatsPerTable;
         int endIdx = Math.min(
            startIdx + seatsPerTable, n);
         List<Integer> tableGuests = 
            new ArrayList<>();
         
         if (startIdx < n) {
            for (int i = startIdx; i < endIdx; 
                 i++) {
               tableGuests.add(guests.get(i));
            }
         }
         
         seating.add(tableGuests);
      }
      
      // Local search optimization
      boolean improved = true;
      while (improved) {
         improved = false;
         int bestSwapGain = 0;
         int[] bestSwap = null;
         
         // Try guest swaps
         for (int t1 = 0; t1 < tables; t1++) {
            for (int t2 = 0; t2 < tables; t2++) {
               if (t1 == t2) continue;
               
               for (int i = 0; 
                    i < seating.get(t1).size(); 
                    i++) {
                  for (int j = 0; 
                       j < seating.get(t2).size(); 
                       j++) {
                     // Skip if table full
                     if (seating.get(t2).size() >= 
                         seatsPerTable) {
                        continue;
                     }
                     
                     int guest1 = seating.get(t1)
                                  .get(i);
                     int guest2 = seating.get(t2)
                                  .get(j);
                     
                     // Calculate old score
                     int oldScore = 
                        tableScore(seating.get(t1), 
                           relationships) + 
                        tableScore(seating.get(t2), 
                           relationships);
                     
                     // Perform swap
                     List<Integer> newT1 = 
                        new ArrayList<>(
                           seating.get(t1));
                     List<Integer> newT2 = 
                        new ArrayList<>(
                           seating.get(t2));
                     newT1.remove(
                        Integer.valueOf(guest1));
                     newT2.remove(
                        Integer.valueOf(guest2));
                     newT1.add(guest2);
                     newT2.add(guest1);
                     
                     // Calculate new score
                     int newScore = 
                        tableScore(newT1, 
                           relationships) + 
                        tableScore(newT2, 
                           relationships);
                     int gain = newScore - oldScore;
                     
                     // Track best swap
                     if (gain > bestSwapGain) {
                        bestSwapGain = gain;
                        bestSwap = new int[]{
                           t1, i, t2, j};
                     }
                  }
               }
            }
         }
         
         // Apply best swap
         if (bestSwapGain > 0) {
            int t1 = bestSwap[0], 
                i = bestSwap[1];
            int t2 = bestSwap[2], 
                j = bestSwap[3];
            int guest1 = seating.get(t1).get(i);
            int guest2 = seating.get(t2).get(j);
            seating.get(t1).remove(i);
            seating.get(t2).remove(j);
            seating.get(t1).add(guest2);
            seating.get(t2).add(guest1);
            improved = true;
         }
      }
      
      return totalScore(seating, relationships);
   }
   
   // Calculate table happiness
   private int tableScore(List<Integer> tableGuests, 
         int[][] relationships) {
      int score = 0;
      for (int i = 0; i < tableGuests.size(); 
           i++) {
         for (int j = i + 1; 
              j < tableGuests.size(); j++) {
            score += relationships[
               tableGuests.get(i)]
               [tableGuests.get(j)];
         }
      }
      return score;
   }
   
   // Calculate total happiness
   private int totalScore(
         List<List<Integer>> seating, 
         int[][] relationships) {
      int score = 0;
      for (List<Integer> table : seating) {
         score += tableScore(table, 
            relationships);
      }
      return score;
   }
}