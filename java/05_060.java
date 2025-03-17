import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
  public static void main(String[] args) {
     // Main method code goes here
  }
  
  /**
   * Custom HashMap implementation
   */
  public static class CustomHashMap<K, V> {
     /**
      * Handle key collision in hash bucket
      */
     public void handleCollision(K key, V value, 
           List<Map.Entry<K, V>> bucket) {
        // Check if key already exists
        for (Map.Entry<K, V> item : bucket) {
           if (item.getKey().equals(key)) {
              // Update existing key's value
              item.setValue(value);
              return;
           }
        }
        // Add new entry if key not found
        bucket.add(new AbstractMap.SimpleEntry<>(key, value));
     }
  }
}