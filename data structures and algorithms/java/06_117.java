import java.util.*;

class HuffmanNode implements Comparable<HuffmanNode> {
    int frequency;
    char character;
    HuffmanNode left;
    HuffmanNode right;
    
    public int compareTo(HuffmanNode node) {
        return frequency - node.frequency;
    }
}

import java.util.HashMap;
import java.util.Map;
import java.util.PriorityQueue;

class HuffmanNode implements Comparable<HuffmanNode> {
   char character;
   int frequency;
   HuffmanNode left;
   HuffmanNode right;
   
   @Override
   public int compareTo(HuffmanNode node) {
      return this.frequency - node.frequency;
   }
}

public class HuffmanCoding {
   public static void main(String[] args) {
      String text = "this is an example for huffman encoding";
      
      // Count character frequencies
      Map<Character, Integer> frequency = new HashMap<>();
      for (char c : text.toCharArray()) {
         frequency.put(c, frequency.getOrDefault(c, 0) + 1);
      }
      
      // Create priority queue of nodes
      PriorityQueue<HuffmanNode> queue = 
            new PriorityQueue<>();
      for (Map.Entry<Character, Integer> entry : 
            frequency.entrySet()) {
         HuffmanNode node = new HuffmanNode();
         node.character = entry.getKey();
         node.frequency = entry.getValue();
         node.left = null;
         node.right = null;
         queue.add(node);
      }
      
      // Build Huffman Tree
      HuffmanNode root = null;
      while (queue.size() > 1) {
         // Extract two nodes with lowest frequency
         HuffmanNode x = queue.poll();
         HuffmanNode y = queue.poll();
         
         // Create new internal node
         HuffmanNode sum = new HuffmanNode();
         sum.frequency = x.frequency + y.frequency;
         sum.character = '-';
         sum.left = x;
         sum.right = y;
         root = sum;
         queue.add(sum);
      }
      
      // Generate codes for each character
      Map<Character, String> codes = new HashMap<>();
      printCode(root, "", codes);
      
      // Display generated codes
      System.out.println("Huffman Codes:");
      for (Map.Entry<Character, String> entry : 
            codes.entrySet()) {
         System.out.println(entry.getKey() + ": " + 
               entry.getValue());
      }
      
      // Encode the original text
      StringBuilder encoded = new StringBuilder();
      for (char c : text.toCharArray()) {
         encoded.append(codes.get(c));
      }
      
      System.out.println("\nEncoded text: " + 
            encoded.toString());
      
      // Calculate compression ratio
      double originalSize = text.length() * 8; // 8 bits per char
      double compressedSize = encoded.length();
      System.out.printf("Compression ratio: %.2f\n", 
            compressedSize / originalSize);
   }
   
   /**
    * Recursively generate Huffman codes
    */
   private static void printCode(HuffmanNode root, String s, 
         Map<Character, String> codes) {
      // Leaf node (actual character)
      if (root.left == null && root.right == null && 
            Character.isLetter(root.character)) {
         codes.put(root.character, s);
         return;
      }
      
      // Traverse left (add 0) and right (add 1)
      printCode(root.left, s + "0", codes);
      printCode(root.right, s + "1", codes);
   }
}