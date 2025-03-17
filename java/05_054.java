import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;

public class Main {
  public static void main(String[] args) {
     // Main method code goes here
  }
  
  /**
   * Tree node with key and children
   */
  public static class Node {
     public int key;
     public Node left;
     public Node right;
     
     public Node(int key) {
        this.key = key;
        this.left = null;
        this.right = null;
     }
  }
  
  /**
   * Convert sorted array to balanced BST
   */
  public Node sortedArrayToBST(int[] nums) {
     if (nums == null || nums.length == 0) {
        return null;
     }
     
     return sortedArrayToBSTHelper(nums, 0, 
        nums.length - 1);
  }
  
  /**
   * Recursive helper for BST creation
   */
  private Node sortedArrayToBSTHelper(int[] nums, 
        int start, int end) {
     if (start > end) {
        return null;
     }
     
     // Find middle element as root
     int mid = start + (end - start) / 2;
     Node root = new Node(nums[mid]);
     
     // Recursively build left and right subtrees
     root.left = sortedArrayToBSTHelper(nums, start, 
        mid - 1);
     root.right = sortedArrayToBSTHelper(nums, mid + 1, 
        end);
     
     return root;
  }
}