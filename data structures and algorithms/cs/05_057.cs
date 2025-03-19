using System;
using System.Collections.Generic;

public class MainClass {
  public static void Main(string[] args) {
     // Main method code goes here
  }
  
  /**
   * Demonstrates map operations and custom implementation
   */
  public void BasicMapUsage() {
     // Basic usage
     Dictionary<string, object> myMap = new Dictionary<string, object>();
     myMap["name"] = "Jane";
     myMap["age"] = 25;

     // Map with squares
     Dictionary<int, int> squareMap = new Dictionary<int, int>();
     for (int i = 0; i < 5; i++) {
        squareMap[i] = i * i;
     }

     // Custom HashMap implementation
     class HashMap<K, V> {
        // Default bucket size
        private static readonly int DEFAULT_SIZE = 100;
        private List<List<KeyValuePair<K, V>>> map;
        
        public HashMap() {
           this.map = new List<List<KeyValuePair<K, V>>>(DEFAULT_SIZE);
           for (int i = 0; i < DEFAULT_SIZE; i++) {
              this.map.Add(new List<KeyValuePair<K, V>>());
           }
        }
        
        /**
         * Get bucket index from key hashcode
         */
        private int GetHash(K key) {
           return Math.Abs(key.GetHashCode() % DEFAULT_SIZE);
        }
        
        /**
         * Store key-value pair in map
         */
        public void Put(K key, V value) {
           int keyHash = GetHash(key);
           List<KeyValuePair<K, V>> bucket = this.map[keyHash];
           
           // Update existing key if found
           for (int i = 0; i < bucket.Count; i++) {
              if (bucket[i].Key.Equals(key)) {
                 bucket[i] = new KeyValuePair<K, V>(key, value);
                 return;
              }
           }
           
           // Add new entry if key not found
           bucket.Add(new KeyValuePair<K, V>(key, value));
        }
     }
  }
}
