import java.util.ArrayList;
import java.util.List;

/**
 * Node in AVL tree for line break tracking
 */
class Node {
   int position;  // Character position of the line break
   Node left, right;
   int height;    // For AVL tree balance
   
   Node(int position) {
      this.position = position;
      this.height = 1;
   }
}

/**
 * Text editor with efficient line tracking using AVL tree
 */
public class TextEditor {
   private StringBuilder text;
   private Node root;  // Root of the AVL tree
   
   public TextEditor() {
      text = new StringBuilder();
      root = null;
   }
   
   /**
    * Insert text at specified position
    */
   public void insert(int position, String str) {
      if (position < 0 || position > text.length()) {
         throw new IllegalArgumentException("Invalid position");
      }
      
      // Update the text
      text.insert(position, str);
      
      // Find new line breaks in the inserted text
      List<Integer> newLinePositions = new ArrayList<>();
      for (int i = 0; i < str.length(); i++) {
         if (str.charAt(i) == '\n') {
            newLinePositions.add(position + i);
         }
      }
      
      // Update existing line break positions
      updatePositions(root, position, str.length());
      
      // Insert new line breaks
      for (int linePos : newLinePositions) {
         root = insertNode(root, linePos);
      }
   }
   
   /**
    * Delete text of specified length at position
    */
   public void delete(int position, int length) {
      if (position < 0 || position + length > text.length()) {
         throw new IllegalArgumentException(
            "Invalid position or length");
      }
      
      // Find line breaks in the deleted text
      String deletedText = text.substring(position, 
                                       position + length);
      List<Integer> deletedLines = new ArrayList<>();
      for (int i = 0; i < deletedText.length(); i++) {
         if (deletedText.charAt(i) == '\n') {
            deletedLines.add(position + i);
         }
      }
      
      // Update the text
      text.delete(position, position + length);
      
      // Remove line breaks in the deleted range
      for (int linePos : deletedLines) {
         root = deleteNode(root, linePos);
      }
      
      // Update remaining line break positions
      updatePositions(root, position, -length);
   }
   
   /**
    * Get line number for character position
    */
   public int getLineNumber(int position) {
      if (position < 0 || position > text.length()) {
         throw new IllegalArgumentException("Invalid position");
      }
      
      // Count line breaks before the position
      return countSmaller(root, position);
   }
   
   /**
    * AVL Tree operations below
    */
   
   // Get height of node
   private int getHeight(Node node) {
      if (node == null) {
         return 0;
      }
      return node.height;
   }
   
   // Calculate balance factor
   private int getBalance(Node node) {
      if (node == null) {
         return 0;
      }
      return getHeight(node.left) - getHeight(node.right);
   }
   
   // Right rotation
   private Node rightRotate(Node y) {
      Node x = y.left;
      Node T2 = x.right;
      
      // Perform rotation
      x.right = y;
      y.left = T2;
      
      // Update heights
      y.height = Math.max(getHeight(y.left), 
                        getHeight(y.right)) + 1;
      x.height = Math.max(getHeight(x.left), 
                        getHeight(x.right)) + 1;
      
      return x;
   }
   
   // Left rotation
   private Node leftRotate(Node x) {
      Node y = x.right;
      Node T2 = y.left;
      
      // Perform rotation
      y.left = x;
      x.right = T2;
      
      // Update heights
      x.height = Math.max(getHeight(x.left), 
                        getHeight(x.right)) + 1;
      y.height = Math.max(getHeight(y.left), 
                        getHeight(y.right)) + 1;
      
      return y;
   }
   
   // Insert node into AVL tree
   private Node insertNode(Node node, int position) {
      // Standard BST insert
      if (node == null) {
         return new Node(position);
      }
      
      if (position < node.position) {
         node.left = insertNode(node.left, position);
      } else if (position > node.position) {
         node.right = insertNode(node.right, position);
      } else {
         // Duplicate positions not allowed
         return node;
      }
      
      // Update height
      node.height = Math.max(getHeight(node.left), 
                           getHeight(node.right)) + 1;
      
      // Get balance factor
      int balance = getBalance(node);
      
      // Balance the tree if needed
      // Left Left Case
      if (balance > 1 && position < node.left.position) {
         return rightRotate(node);
      }
      
      // Right Right Case
      if (balance < -1 && position > node.right.position) {
         return leftRotate(node);
      }
      
      // Left Right Case
      if (balance > 1 && position > node.left.position) {
         node.left = leftRotate(node.left);
         return rightRotate(node);
      }
      
      // Right Left Case
      if (balance < -1 && position < node.right.position) {
         node.right = rightRotate(node.right);
         return leftRotate(node);
      }
      
      return node;
   }
   
   // Delete node from AVL tree
   private Node deleteNode(Node node, int position) {
      if (node == null) {
         return node;
      }
      
      if (position < node.position) {
         node.left = deleteNode(node.left, position);
      } else if (position > node.position) {
         node.right = deleteNode(node.right, position);
      } else {
         // Node to be deleted found
         
         // Node with one child or no child
         if (node.left == null) {
            return node.right;
         } else if (node.right == null) {
            return node.left;
         }
         
         // Node with two children
         Node successor = getMinValueNode(node.right);
         node.position = successor.position;
         node.right = deleteNode(node.right, 
                              successor.position);
      }
      
      // If tree had only one node
      if (node == null) {
         return node;
      }
      
      // Update height
      node.height = Math.max(getHeight(node.left), 
                           getHeight(node.right)) + 1;
      
      // Get balance factor
      int balance = getBalance(node);
      
      // Balance the tree if needed
      // Left Left Case
      if (balance > 1 && getBalance(node.left) >= 0) {
         return rightRotate(node);
      }
      
      // Left Right Case
      if (balance > 1 && getBalance(node.left) < 0) {
         node.left = leftRotate(node.left);
         return rightRotate(node);
      }
      
      // Right Right Case
      if (balance < -1 && getBalance(node.right) <= 0) {
         return leftRotate(node);
      }
      
      // Right Left Case
      if (balance < -1 && getBalance(node.right) > 0) {
         node.right = rightRotate(node.right);
         return leftRotate(node);
      }
      
      return node;
   }
   
   // Find minimum value node (leftmost leaf)
   private Node getMinValueNode(Node node) {
      Node current = node;
      while (current.left != null) {
         current = current.left;
      }
      return current;
   }
   
   // Update positions after text modification
   private void updatePositions(Node node, int startPos, 
         int shift) {
      if (node == null) {
         return;
      }
      
      if (node.position >= startPos) {
         node.position += shift;
      }
      
      // Update right subtree
      updatePositions(node.right, startPos, shift);
      
      // Only update left if current node was shifted
      if (node.position >= startPos) {
         updatePositions(node.left, startPos, shift);
      }
   }
   
   // Count nodes with position < given position
   private int countSmaller(Node node, int position) {
      if (node == null) {
         return 0;
      }
      
      if (position < node.position) {
         return countSmaller(node.left, position);
      } else {
         return 1 + countSmaller(node.left, position) + 
                countSmaller(node.right, position);
      }
   }
}