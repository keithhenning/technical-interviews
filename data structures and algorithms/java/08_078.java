import java.util.*;

public class OptimalRaceDayStrategy {
   private int[][] performanceRatings;
   private int[] raceCapacity;
   private Set<Pair<Integer, Integer>> ineligible;
   private int[] bestAssignment;
   private int bestPoints;
   private int nHorses;
   private int nRaces;
   
   public OptimalRaceDayStrategy(int[][] performanceRatings, 
         int[] raceCapacity, List<int[]> ineligibility) {
      this.performanceRatings = performanceRatings;
      this.raceCapacity = raceCapacity;
      this.ineligible = new HashSet<>();
      
      for (int[] pair : ineligibility) {
         this.ineligible.add(new Pair<>(pair[0], pair[1]));
      }
      
      this.nHorses = performanceRatings.length;
      this.nRaces = raceCapacity.length;
      this.bestAssignment = new int[nHorses];
      this.bestPoints = 0;
   }
   
   public int[] optimizeRaces() {
      // Initialize race assignment array
      int[] currentAssignment = new int[nHorses];
      Arrays.fill(currentAssignment, -1);
      int[] raceCounts = new int[nRaces];
      
      // Start backtracking optimization
      backtrack(0, currentAssignment, raceCounts, 0);
      
      // Return best assignment or null
      return bestPoints > 0 ? bestAssignment : null;
   }
   
   private void backtrack(int horseIdx, int[] assignments, 
         int[] raceCounts, int totalPoints) {
      // All horses assigned
      if (horseIdx == nHorses) {
         // Verify all races have horses
         boolean allRacesHaveHorses = true;
         for (int count : raceCounts) {
            if (count == 0) {
               allRacesHaveHorses = false;
               break;
            }
         }
         
         // Update best assignment if valid
         if (allRacesHaveHorses && totalPoints > bestPoints) {
            bestPoints = totalPoints;
            System.arraycopy(assignments, 0, bestAssignment, 
                  0, nHorses);
         }
         return;
      }
      
      // Try each race for current horse
      for (int race = 0; race < nRaces; race++) {
         // Skip if ineligible or race full
         if (ineligible.contains(new Pair<>(horseIdx, race)) || 
               raceCounts[race] >= raceCapacity[race]) {
            continue;
         }
         
         // Assign horse to race
         assignments[horseIdx] = race;
         raceCounts[race]++;
         
         // Recursive backtracking
         backtrack(horseIdx + 1, assignments, raceCounts, 
               totalPoints + performanceRatings[horseIdx][race]);
         
         // Undo assignment
         raceCounts[race]--;
         assignments[horseIdx] = -1;
      }
   }
   
   public int getBestPoints() {
      return bestPoints;
   }
   
   // Pair helper class with equals and hashCode
   static class Pair<K, V> {
      private final K key;
      private final V value;
      
      public Pair(K key, V value) {
         this.key = key;
         this.value = value;
      }
      
      @Override
      public boolean equals(Object o) {
         if (this == o) return true;
         if (o == null || getClass() != o.getClass()) 
            return false;
         Pair<?, ?> pair = (Pair<?, ?>) o;
         return Objects.equals(key, pair.key) && 
               Objects.equals(value, pair.value);
      }
      
      @Override
      public int hashCode() {
         return Objects.hash(key, value);
      }
   }
   
   public static void main(String[] args) {
      // Sample race ratings
      int[][] ratings = {
         {80, 40, 60},
         {20, 90, 30},
         {45, 50, 70},
         {60, 45, 30},
         {50, 55, 55}
      };
      
      // Race capacities
      int[] capacity = {2, 2, 2};
      
      // Ineligible race/horse combinations
      List<int[]> ineligibility = new ArrayList<>();
      ineligibility.add(new int[]{0, 1});
      ineligibility.add(new int[]{3, 2});
      
      // Create and run strategy
      OptimalRaceDayStrategy strategy = 
            new OptimalRaceDayStrategy(ratings, capacity, 
                  ineligibility);
      int[] assignments = strategy.optimizeRaces();
      
      // Print results
      System.out.println("Maximum points: " + 
            strategy.getBestPoints());
      System.out.print("Assignments: ");
      for (int i = 0; i < assignments.length; i++) {
         System.out.print("Horse " + i + " &#x2192; Race " + 
               assignments[i] + ", ");
      }
   }
}