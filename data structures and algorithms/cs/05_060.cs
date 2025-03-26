using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   /**
    * Custom HashMap implementation
    */
   public class CustomHashMap<K, V>
   {
      /**
       * Handle key collision in hash bucket
       */
      public void HandleCollision(K key, V value,
         List<KeyValuePair<K, V>> bucket)
      {
         // Check if key already exists
         for (int i = 0; i < bucket.Count; i++)
         {
            if (EqualityComparer<K>.Default.Equals(
               bucket[i].Key, key))
            {
               // Update existing key's value
               bucket[i] = new KeyValuePair<K, V>(key,
                  value);
               return;
            }
         }
         // Add new entry if key not found
         bucket.Add(new KeyValuePair<K, V>(key, value));
      }

      public void Resize()
      {
         // Implementation for resizing the hash map
      }
   }
}
