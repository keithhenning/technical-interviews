import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
  public static void main(String[] args) {
     // Main method code goes here
  }
  
  /**
   * Demonstrates map operations and custom implementation
   */
  public void basicMapUsage() {
     // Basic usage
     Map<String, Object> myMap = new HashMap<>();
     myMap.put("name", "Jane");
     myMap.put("age", 25);

     // Map with squares
     Map<Integer, Integer> squareMap = new HashMap<>();
     for (int i = 0; i < 5; i++) {
        squareMap.put(i, i*i);
     }

     // Custom HashMap implementation
     class HashMap<K, V> {
        // Default bucket size
        private static final int DEFAULT_SIZE = 100;
        private List<List<Entry<K, V>>> map;
        
        public HashMap() {
           this.map = new ArrayList<>(DEFAULT_SIZE);
           for (int i = 0; i < DEFAULT_SIZE; i++) {
              this.map.add(new ArrayList<>());
           }
        }
        
        /**
         * Get bucket index from key hashcode
         */
        private int getHash(K key) {
           return Math.abs(key.hashCode() % DEFAULT_SIZE);
        }
        
        /**
         * Store key-value pair in map
         */
        public void put(K key, V value) {
           int keyHash = getHash(key);
           List<Entry<K, V>> bucket = this.map.get(keyHash);
           
           // Update existing key if found
           for (Entry<K, V> pair : bucket) {
              if (pair.getKey().equals(key)) {
                 pair.setValue(value);
                 return;
              }
           }
           
           // Add new entry if key not found
           bucket.add(new AbstractMap.SimpleEntry<>(key, 
              value));
        }
     }
  }
}