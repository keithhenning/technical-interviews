using System;
using System.Collections.Generic;

public class HashtagAnalyzer
{
   public List<string> TopKTrendingHashtags(
       string[] hashtags,
       int k)
   {
      // Count frequencies
      Dictionary<string, int> counter =
          new Dictionary<string, int>();
      foreach (string tag in hashtags)
      {
         if (counter.ContainsKey(tag))
         {
            counter[tag]++;
         }
         else
         {
            counter[tag] = 1;
         }
      }

      // Use priority queue (min heap)
      PriorityQueue<string> heap = new PriorityQueue<string>(
          Comparer<string>.Create(
              (a, b) => counter[a] - counter[b]));

      foreach (string tag in counter.Keys)
      {
         heap.Enqueue(tag);
         if (heap.Count > k)
         {
            heap.Dequeue();
         }
      }

      // Build result list
      List<string> result = new List<string>();
      while (heap.Count > 0)
      {
         result.Insert(0, heap.Dequeue());
      }

      return result;
   }
}