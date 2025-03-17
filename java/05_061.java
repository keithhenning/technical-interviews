import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
    public static void main(String[] args) {
        // Main method code goes here
    }
    
    public class CustomHashMap<K, V> {
        private int size;
        private List<List<Map.Entry<K, V>>> buckets;
        
        public boolean shouldResize() {
            return (double) this.size / this.buckets.size() > 0.75;
        }
    }
}