using System;
using System.Collections.Generic;

public class Solution 
{
   public int MaxWeddingHappiness(
      int[][] relationships,
      int tables,
      int seatsPerTable) 
   {
      int n = relationships.Length;
      if (n > tables * seatsPerTable) 
      {
         return -1;  // Not enough seats
      }

      List<int> guests = new List<int>();
      for (int i = 0; i < n; i++) 
      {
         guests.Add(i);
      }
      Random rng = new Random();
      guests.Sort((a, b) => rng.Next(-1, 2));

      List<List<int>> seating = new List<List<int>>();
      for (int t = 0; t < tables; t++) 
      {
         int startIdx = t * seatsPerTable;
         int endIdx = Math.Min(startIdx + seatsPerTable, n);
         List<int> tableGuests = new List<int>();

         if (startIdx < n) 
         {
            for (int i = startIdx; i < endIdx; i++) 
            {
               tableGuests.Add(guests[i]);
            }
         }

         seating.Add(tableGuests);
      }

      bool improved = true;
      while (improved) 
      {
         improved = false;
         int bestSwapGain = 0;
         int[] bestSwap = null;

         for (int t1 = 0; t1 < tables; t1++) 
         {
            for (int t2 = 0; t2 < tables; t2++) 
            {
               if (t1 == t2) continue;

               for (int i = 0; i < seating[t1].Count; i++) 
               {
                  for (int j = 0; j < seating[t2].Count; j++) 
                  {
                     if (seating[t2].Count >= seatsPerTable) 
                     {
                        continue;
                     }

                     int guest1 = seating[t1][i];
                     int guest2 = seating[t2][j];

                     int oldScore =
                        TableScore(seating[t1], relationships) +
                        TableScore(seating[t2], relationships);

                     List<int> newT1 = 
                        new List<int>(seating[t1]);
                     List<int> newT2 = 
                        new List<int>(seating[t2]);
                     newT1.Remove(guest1);
                     newT2.Remove(guest2);
                     newT1.Add(guest2);
                     newT2.Add(guest1);

                     int newScore =
                        TableScore(newT1, relationships) +
                        TableScore(newT2, relationships);
                     int gain = newScore - oldScore;

                     if (gain > bestSwapGain) 
                     {
                        bestSwapGain = gain;
                        bestSwap = new int[]{ t1, i, t2, j };
                     }
                  }
               }
            }
         }

         if (bestSwapGain > 0) 
         {
            int t1 = bestSwap[0], i = bestSwap[1];
            int t2 = bestSwap[2], j = bestSwap[3];
            int guest1 = seating[t1][i];
            int guest2 = seating[t2][j];
            seating[t1].RemoveAt(i);
            seating[t2].RemoveAt(j);
            seating[t1].Add(guest2);
            seating[t2].Add(guest1);
            improved = true;
         }
      }

      return TotalScore(seating, relationships);
   }

   private int TableScore(
      List<int> tableGuests,
      int[][] relationships) 
   {
      int score = 0;
      for (int i = 0; i < tableGuests.Count; i++) 
      {
         for (int j = i + 1; j < tableGuests.Count; j++) 
         {
            score += relationships[tableGuests[i]]
               [tableGuests[j]];
         }
      }
      return score;
   }

   private int TotalScore(
      List<List<int>> seating,
      int[][] relationships) 
   {
      int score = 0;
      foreach (List<int> table in seating) 
      {
         score += TableScore(table, relationships);
      }
      return score;
   }
}
