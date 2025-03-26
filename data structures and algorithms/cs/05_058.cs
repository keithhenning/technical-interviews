using System;
using System.Collections.Generic;
using System.Linq;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   /**
    * Generic cache with usage-based eviction policy
    */
   public static class Cache<K, V>
   {
      private int capacity;
      private Dictionary<K, V> cache;
      private Dictionary<K, int> usage;

      /**
       * Create a cache with specified capacity
       */
      public Cache(int capacity)
      {
         this.capacity = capacity;
         this.cache = new Dictionary<K, V>();
         this.usage = new Dictionary<K, int>();
      }

      /**
       * Get value and update usage count
       */
      public V Get(K key)
      {
         if (this.cache.ContainsKey(key))
         {
            this.usage[key]++;
            return this.cache[key];
         }
         return default(V);
      }

      /**
       * Add or update key-value, evicting if needed
       */
      public void Put(K key, V value)
      {
         // Eviction needed if at capacity
         if (this.cache.Count >= this.capacity &&
               !this.cache.ContainsKey(key))
         {
            // Find least frequently used item
            K leastUsed = this.usage.Aggregate(
               (l, r) => l.Value < r.Value ? l : r).Key;
            this.cache.Remove(leastUsed);
            this.usage.Remove(leastUsed);
         }

         this.cache[key] = value;
         // Initialize or reset usage count
         this.usage[key] = 1;
      }
   }
}
