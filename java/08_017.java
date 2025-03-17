import java.util.*;

/**
 * Cache that uses frequency and recency for eviction
 */
public class IntelligentCache<K, V> {
   private final int capacity;
   private final Map<K, CacheItem<K, V>> cache;
   
   /**
    * Create cache with specified capacity
    */
   public IntelligentCache(int capacity) {
      this.capacity = capacity;
      this.cache = new HashMap<>();
   }
   
   /**
    * Retrieve value and update access statistics
    */
   public V get(K key) {
      if (!cache.containsKey(key)) {
         return null;
      }
      
      // Update frequency and last access time
      CacheItem<K, V> item = cache.get(key);
      item.access();
      return item.value;
   }
   
   /**
    * Store value in cache, evicting if needed
    */
   public void put(K key, V value) {
      // Update existing item if key present
      if (cache.containsKey(key)) {
         CacheItem<K, V> item = cache.get(key);
         item.value = value;
         item.access();
         return;
      }
      
      // Evict if cache is full
      if (cache.size() >= capacity) {
         evict();
      }
      
      // Add new item
      cache.put(key, new CacheItem<>(key, value));
   }
   
   /**
    * Evict the least valuable item from cache
    */
   private void evict() {
      if (cache.isEmpty()) {
         return;
      }
      
      double minScore = Double.POSITIVE_INFINITY;
      K minKey = null;
      long currentTime = System.currentTimeMillis();
      
      // Find item with minimum value score
      for (Map.Entry<K, CacheItem<K, V>> entry : 
            cache.entrySet()) {
         CacheItem<K, V> item = entry.getValue();
         double score = item.getScore(currentTime);
         if (score < minScore) {
            minScore = score;
            minKey = entry.getKey();
         }
      }
      
      // Remove the item
      if (minKey != null) {
         cache.remove(minKey);
      }
   }
   
   /**
    * Inner class to store cache items with metadata
    */
   private static class CacheItem<K, V> {
      final K key;
      V value;
      int frequency;
      long lastAccess;
      
      CacheItem(K key, V value) {
         this.key = key;
         this.value = value;
         this.frequency = 1;
         this.lastAccess = System.currentTimeMillis();
      }
      
      /**
       * Update access statistics
       */
      void access() {
         frequency++;
         lastAccess = System.currentTimeMillis();
      }
      
      /**
       * Calculate item value based on frequency and recency
       */
      double getScore(long currentTime) {
         // Calculate recency in seconds
         double recencyScore = 1.0 / 
               (1.0 + (currentTime - lastAccess) / 1000.0);
         return frequency * recencyScore;
      }
   }
}