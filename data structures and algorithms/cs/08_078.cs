using System;
using System.Collections.Generic;

public class OptimalRaceDayStrategy
{
   private int[][] performanceRatings;
   private int[] raceCapacity;
   private HashSet<Pair<int, int>> ineligible;
   private int[] bestAssignment;
   private int bestPoints;
   private int nHorses;
   private int nRaces;

   public OptimalRaceDayStrategy(
      int[][] performanceRatings,
      int[] raceCapacity,
      List<int[]> ineligibility)
   {
      this.performanceRatings = performanceRatings;
      this.raceCapacity = raceCapacity;
      this.ineligible = new HashSet<Pair<int, int>>();

      foreach (int[] pair in ineligibility)
      {
         this.ineligible.Add(
            new Pair<int, int>(pair[0], pair[1]));
      }

      this.nHorses = performanceRatings.Length;
      this.nRaces = raceCapacity.Length;
      this.bestAssignment = new int[nHorses];
      this.bestPoints = 0;
   }

   public int[] OptimizeRaces()
   {
      int[] currentAssignment = new int[nHorses];
      Array.Fill(currentAssignment, -1);
      int[] raceCounts = new int[nRaces];

      Backtrack(
         0, 
         currentAssignment, 
         raceCounts, 
         0);

      return bestPoints > 0 ? bestAssignment : null;
   }

   private void Backtrack(
      int horseIdx,
      int[] assignments,
      int[] raceCounts,
      int totalPoints)
   {
      if (horseIdx == nHorses)
      {
         bool allRacesHaveHorses = true;
         foreach (int count in raceCounts)
         {
            if (count == 0)
            {
               allRacesHaveHorses = false;
               break;
            }
         }

         if (allRacesHaveHorses && totalPoints > bestPoints)
         {
            bestPoints = totalPoints;
            Array.Copy(
               assignments, 
               bestAssignment, 
               nHorses);
         }
         return;
      }

      for (int race = 0; race < nRaces; race++)
      {
         if (ineligible.Contains(
               new Pair<int, int>(horseIdx, race)) ||
            raceCounts[race] >= raceCapacity[race])
         {
            continue;
         }

         assignments[horseIdx] = race;
         raceCounts[race]++;

         Backtrack(
            horseIdx + 1,
            assignments,
            raceCounts,
            totalPoints + performanceRatings[horseIdx][race]);

         raceCounts[race]--;
         assignments[horseIdx] = -1;
      }
   }

   public int GetBestPoints()
   {
      return bestPoints;
   }

   public class Pair<K, V>
   {
      private readonly K key;
      private readonly V value;

      public Pair(K key, V value)
      {
         this.key = key;
         this.value = value;
      }

      public override bool Equals(object obj)
      {
         if (this == obj) return true;
         if (obj == null || GetType() != obj.GetType())
            return false;
         Pair<K, V> pair = (Pair<K, V>)obj;
         return EqualityComparer<K>.Default.Equals(
                  key, pair.key) &&
            EqualityComparer<V>.Default.Equals(
                  value, pair.value);
      }

      public override int GetHashCode()
      {
         return HashCode.Combine(key, value);
      }
   }

   public static void Main(string[] args)
   {
      int[][] ratings = {
         new int[] {80, 40, 60},
         new int[] {20, 90, 30},
         new int[] {45, 50, 70},
         new int[] {60, 45, 30},
         new int[] {50, 55, 55}
      };

      int[] capacity = { 2, 2, 2 };

      List<int[]> ineligibility = new List<int[]>();
      ineligibility.Add(new int[] { 0, 1 });
      ineligibility.Add(new int[] { 3, 2 });

      OptimalRaceDayStrategy strategy =
         new OptimalRaceDayStrategy(
            ratings,
            capacity,
            ineligibility);
      int[] assignments = strategy.OptimizeRaces();

      Console.WriteLine(
         "Maximum points: " + strategy.GetBestPoints());
      Console.Write("Assignments: ");
      for (int i = 0; i < assignments.Length; i++)
      {
         Console.Write(
            "Horse " + i + " → Race " + assignments[i] + ", ");
      }
   }
}
