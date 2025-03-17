import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
   public static void main(String[] args) {
      // Main method code goes here
   }
   
   /**
    * Generic cache with usage-based eviction policy
    */
   public static class Cache<K, V> {
      private int capacity;
      private Map<K, V> cache;
      private Map<K, Integer> usage;
      
      /**
       * Create a cache with specified capacity
       */
      public Cache(int capacity) {
         this.capacity = capacity;
         this.cache = new HashMap<>();
         this.usage = new HashMap<>();
      }
      
      /**
       * Get value and update usage count
       */
      public V get(K key) {
         if (this.cache.containsKey(key)) {
            this.usage.put(key, this.usage.get(key) + 1);
            return this.cache.get(key);
         }
         return null;
      }
      
      /**
       * Add or update key-value, evicting if needed
       */
      public void put(K key, V value) {
         // Eviction needed if at capacity
         if (this.cache.size() >= this.capacity && 
               !this.cache.containsKey(key)) {
            // Find least frequently used item
            K leastUsed = Collections.min(
               this.usage.entrySet(), 
               Map.Entry.comparingByValue()).getKey();
            this.cache.remove(leastUsed);
            this.usage.remove(leastUsed);
         }
         
         this.cache.put(key, value);
         // Initialize or reset usage count
         this.usage.put(key, 1);
      }
   }
}