using System;
using System.Collections.Generic;
using System.Linq;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   /**
    * Node in a binary tree with value and children
    */
   public static class Node
   {
      // The value stored in the node
      public int Value;

      // Reference to left child
      public Node Left;

      // Reference to right child
      public Node Right;

      /**
       * Initialize a new Node with a value
       */
      public Node(int value)
      {
         this.Value = value;
         this.Left = null;
         this.Right = null;
      }
   }

   /**
    * Binary search tree implementation
    */
   public static class BinaryTree
   {
      // Reference to the root node
      private Node Root;

      /**
       * Initialize an empty binary tree
       */
      public BinaryTree()
      {
         this.Root = null;
      }

      /**
       * Add node with given value to the BST
       */
      public string AddChild(int value)
      {
         // Handle empty tree case
         if (this.Root == null)
         {
            this.Root = new Node(value);
            return null;
         }

         // Start at the root
         Node current = this.Root;
         bool added = false;

         // Find proper insertion point
         while (!added && current != null)
         {
            // Check for duplicates
            if (value == current.Value)
            {
               return "Duplicates cannot be added";
            }

            if (value < current.Value)
            {
               // Go left for smaller values
               if (current.Left == null)
               {
                  current.Left = new Node(value);
                  added = true;
               }
               else
               {
                  current = current.Left;
               }
            }
            else
            {
               // Go right for larger values
               if (current.Right == null)
               {
                  current.Right = new Node(value);
                  added = true;
               }
               else
               {
                  current = current.Right;
               }
            }
         }
         return null;
      }

      /**
       * Remove node with given value from the BST
       */
      public string RemoveChild(int value)
      {
         Node current = this.Root;
         bool found = false;
         Node nodeToRemove = null;
         Node parent = null;

         // Find node to remove and its parent
         while (!found)
         {
            if (current == null || current.Value == 0)
            {
               return "Node not found";
            }

            if (value == current.Value)
            {
               nodeToRemove = current;
               found = true;
            }
            else if (value < current.Value)
            {
               parent = current;
               current = current.Left;
            }
            else
            {
               parent = current;
               current = current.Right;
            }
         }

         Console.WriteLine("Node found!");

         // Check if target is parent's left child
         bool isLeftChild = parent.Left == nodeToRemove;

         // Case 1: Leaf node (no children)
         if (nodeToRemove.Left == null &&
             nodeToRemove.Right == null)
         {
            if (isLeftChild)
            {
               parent.Left = null;
            }
            else
            {
               parent.Right = null;
            }

            // Case 2: Only has left child
         }
         else if (nodeToRemove.Left != null &&
                   nodeToRemove.Right == null)
         {
            if (isLeftChild)
            {
               parent.Left = nodeToRemove.Left;
            }
            else
            {
               parent.Right = nodeToRemove.Left;
            }

            // Case 3: Only has right child
         }
         else if (nodeToRemove.Right != null &&
                   nodeToRemove.Left == null)
         {
            if (isLeftChild)
            {
               parent.Left = nodeToRemove.Right;
            }
            else
            {
               parent.Right = nodeToRemove.Right;
            }

            // Case 4: Has both children
         }
         else
         {
            // Store subtrees
            Node rightSubtree = nodeToRemove.Right;
            Node leftSubtree = nodeToRemove.Left;

            // Replace with right subtree
            if (isLeftChild)
            {
               parent.Left = rightSubtree;
            }
            else
            {
               parent.Right = rightSubtree;
            }

            // Find leftmost spot in right subtree
            Node currLeft = rightSubtree;
            Node currLeftParent = null;
            bool foundSpace = false;

            while (!foundSpace)
            {
               if (currLeft == null)
               {
                  foundSpace = true;
               }
               else
               {
                  currLeftParent = currLeft;
                  currLeft = currLeft.Left;
               }
            }

            // Attach left subtree
            currLeftParent.Left = leftSubtree;
            return "Node successfully deleted";
         }
         return "Node successfully deleted";
      }

      /**
       * Helper method for tree traversal
       */
      private void _Traverse(Node node,
            Action<Node> visitFunc, string traversalType)
      {
         if (node == null)
         {
            return;
         }

         if (traversalType.Equals("preorder"))
         {
            // Root, left, right
            visitFunc(node);
         }

         // Traverse left subtree
         _Traverse(node.Left, visitFunc, traversalType);

         if (traversalType.Equals("inorder"))
         {
            // Left, root, right
            visitFunc(node);
         }

         // Traverse right subtree
         _Traverse(node.Right, visitFunc, traversalType);

         if (traversalType.Equals("postorder"))
         {
            // Left, right, root
            visitFunc(node);
         }
      }

      /**
       * Print tree values in specified traversal order
       */
      public string PrintTree(string traversalType)
      {
         List<string> result = new List<string>();

         Action<Node> visitFunc = (node) =>
         {
            result.Add(node.Value.ToString());
         };

         _Traverse(this.Root, visitFunc, traversalType);

         return string.Join(" => ", result);
      }
   }

   /**
    * Test the binary tree implementation
    */
   public void TestBinaryTree()
   {
      BinaryTree tree = new BinaryTree();

      // Add nodes
      int[] valuesToAdd = { 50, 30, 70, 20, 40, 60, 80 };
      for (int value : valuesToAdd)
      {
         tree.AddChild(value);
      }

      Console.WriteLine("Tree created with values: " +
         string.Join(", ", valuesToAdd));

      // Print different traversals
      Console.WriteLine("Inorder traversal: " +
         tree.PrintTree("inorder"));
      Console.WriteLine("Preorder traversal: " +
         tree.PrintTree("preorder"));
      Console.WriteLine("Postorder traversal: " +
         tree.PrintTree("postorder"));

      // Test duplicate addition
      string result = tree.AddChild(50);
      Console.WriteLine("Adding duplicate (50): " + result);

      // Remove leaf node
      Console.WriteLine("\nRemoving leaf node (20):");
      tree.RemoveChild(20);
      Console.WriteLine("Inorder after: " +
         tree.PrintTree("inorder"));

      // Remove node with one child
      Console.WriteLine("\nRemoving node with one child:");
      tree.AddChild(65);
      Console.WriteLine("After adding 65: " +
         tree.PrintTree("inorder"));
      tree.RemoveChild(60);
      Console.WriteLine("After removing 60: " +
         tree.PrintTree("inorder"));

      // Remove node with two children
      Console.WriteLine("\nRemoving node with two children:");
      Console.WriteLine("Before removing 30: " +
         tree.PrintTree("inorder"));
      tree.RemoveChild(30);
      Console.WriteLine("After removing 30: " +
         tree.PrintTree("inorder"));
   }
}
