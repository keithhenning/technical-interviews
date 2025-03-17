import java.util.*;
import java.util.stream.*;
import java.io.*;
import java.math.*;
import java.util.function.Consumer;

public class Main {
   public static void main(String[] args) {
      // Main method code goes here
   }
   
   /**
    * Node in a binary tree with value and children
    */
   public static class Node {
      // The value stored in the node
      public int value;
      
      // Reference to left child
      public Node left;
      
      // Reference to right child
      public Node right;
      
      /**
       * Initialize a new Node with a value
       */
      public Node(int value) {
         this.value = value;
         this.left = null;
         this.right = null;
      }
   }

   /**
    * Binary search tree implementation
    */
   public static class BinaryTree {
      // Reference to the root node
      private Node root;
      
      /**
       * Initialize an empty binary tree
       */
      public BinaryTree() {
         this.root = null;
      }

      /**
       * Add node with given value to the BST
       */
      public String addChild(int value) {
         // Handle empty tree case
         if (this.root == null) {
            this.root = new Node(value);
            return null;
         }
         
         // Start at the root
         Node current = this.root;
         boolean added = false;
         
         // Find proper insertion point
         while (!added && current != null) {
            // Check for duplicates
            if (value == current.value) {
               return "Duplicates cannot be added";
            }
               
            if (value < current.value) {
               // Go left for smaller values
               if (current.left == null) {
                  current.left = new Node(value);
                  added = true;
               } else {
                  current = current.left;
               }
            } else {
               // Go right for larger values
               if (current.right == null) {
                  current.right = new Node(value);
                  added = true;
               } else {
                  current = current.right;
               }
            }
         }
         return null;
      }

      /**
       * Remove node with given value from the BST
       */
      public String removeChild(int value) {
         Node current = this.root;
         boolean found = false;
         Node nodeToRemove = null;
         Node parent = null;
         
         // Find node to remove and its parent
         while (!found) {
            if (current == null || current.value == 0) {
               return "Node not found";
            }
               
            if (value == current.value) {
               nodeToRemove = current;
               found = true;
            } else if (value < current.value) {
               parent = current;
               current = current.left;
            } else {
               parent = current;
               current = current.right;
            }
         }
             
         System.out.println("Node found!");
         
         // Check if target is parent's left child
         boolean isLeftChild = parent.left == nodeToRemove;
         
         // Case 1: Leaf node (no children)
         if (nodeToRemove.left == null && 
             nodeToRemove.right == null) {
            if (isLeftChild) {
               parent.left = null;
            } else {
               parent.right = null;
            }
               
         // Case 2: Only has left child
         } else if (nodeToRemove.left != null && 
                   nodeToRemove.right == null) {
            if (isLeftChild) {
               parent.left = nodeToRemove.left;
            } else {
               parent.right = nodeToRemove.left;
            }
               
         // Case 3: Only has right child
         } else if (nodeToRemove.right != null && 
                   nodeToRemove.left == null) {
            if (isLeftChild) {
               parent.left = nodeToRemove.right;
            } else {
               parent.right = nodeToRemove.right;
            }
               
         // Case 4: Has both children
         } else {
            // Store subtrees
            Node rightSubtree = nodeToRemove.right;
            Node leftSubtree = nodeToRemove.left;
            
            // Replace with right subtree
            if (isLeftChild) {
               parent.left = rightSubtree;
            } else {
               parent.right = rightSubtree;
            }
               
            // Find leftmost spot in right subtree
            Node currLeft = rightSubtree;
            Node currLeftParent = null;
            boolean foundSpace = false;
            
            while (!foundSpace) {
               if (currLeft == null) {
                  foundSpace = true;
               } else {
                  currLeftParent = currLeft;
                  currLeft = currLeft.left;
               }
            }
               
            // Attach left subtree
            currLeftParent.left = leftSubtree;
            return "Node successfully deleted";
         }
         return "Node successfully deleted";
      }

      /**
       * Helper method for tree traversal
       */
      private void _traverse(Node node, 
            Consumer<Node> visitFunc, String traversalType) {
         if (node == null) {
            return;
         }
             
         if (traversalType.equals("preorder")) {
            // Root, left, right
            visitFunc.accept(node);
         }
         
         // Traverse left subtree
         _traverse(node.left, visitFunc, traversalType);
         
         if (traversalType.equals("inorder")) {
            // Left, root, right
            visitFunc.accept(node);
         }
         
         // Traverse right subtree
         _traverse(node.right, visitFunc, traversalType);
         
         if (traversalType.equals("postorder")) {
            // Left, right, root
            visitFunc.accept(node);
         }
      }

      /**
       * Print tree values in specified traversal order
       */
      public String printTree(String traversalType) {
         List<String> result = new ArrayList<>();
         
         Consumer<Node> visitFunc = (node) -> {
            result.add(String.valueOf(node.value));
         };
             
         _traverse(this.root, visitFunc, traversalType);
         
         return String.join(" => ", result);
      }
   }

   /**
    * Test the binary tree implementation
    */
   public void testBinaryTree() {
      BinaryTree tree = new BinaryTree();
      
      // Add nodes
      int[] valuesToAdd = {50, 30, 70, 20, 40, 60, 80};
      for (int value : valuesToAdd) {
         tree.addChild(value);
      }
      
      System.out.println("Tree created with values: " + 
         Arrays.toString(valuesToAdd));
      
      // Print different traversals
      System.out.println("Inorder traversal: " + 
         tree.printTree("inorder"));
      System.out.println("Preorder traversal: " + 
         tree.printTree("preorder"));
      System.out.println("Postorder traversal: " + 
         tree.printTree("postorder"));
      
      // Test duplicate addition
      String result = tree.addChild(50);
      System.out.println("Adding duplicate (50): " + result);
      
      // Remove leaf node
      System.out.println("\nRemoving leaf node (20):");
      tree.removeChild(20);
      System.out.println("Inorder after: " + 
         tree.printTree("inorder"));
      
      // Remove node with one child
      System.out.println("\nRemoving node with one child:");
      tree.addChild(65);
      System.out.println("After adding 65: " + 
         tree.printTree("inorder"));
      tree.removeChild(60);
      System.out.println("After removing 60: " + 
         tree.printTree("inorder"));
      
      // Remove node with two children
      System.out.println("\nRemoving node with two children:");
      System.out.println("Before removing 30: " + 
         tree.printTree("inorder"));
      tree.removeChild(30);
      System.out.println("After removing 30: " + 
         tree.printTree("inorder"));
   }
}