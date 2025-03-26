using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   public class CustomHashMap<K, V>
   {
      private int size;
      private List<List<KeyValuePair<K, V>>> buckets;

      public bool ShouldResize()
      {
         return (double)this.size / this.buckets.Count > 0.75;
      }

      public void Add(K key, V value)
      {
         // Implementation for adding a key-value pair
      }
   }
}
