using System;
using System.Collections.Generic;

public class RedBlackTree
{
   private static readonly bool RED = true;
   private static readonly bool BLACK = false;

   private class Node
   {
      public int Key;
      public Node Left, Right, Parent;
      public bool Color; // true for red, false for black

      public Node(int key)
      {
         this.Key = key;
         this.Color = RED;
         this.Left = NIL;
         this.Right = NIL;
      }
   }

   private static readonly Node NIL = new Node(0)
   {
      Color = BLACK
   };
   private Node root = NIL;

   public void Insert(int key)
   {
      Node node = new Node(key);

      Node y = NIL;
      Node x = root;

      // Find position for new node
      while (x != NIL)
      {
         y = x;
         if (node.Key < x.Key)
         {
            x = x.Left;
         }
         else
         {
            x = x.Right;
         }
      }

      // Set parent of node
      node.Parent = y;

      // If tree is empty, make node the root
      if (y == NIL)
      {
         root = node;
      }
      else if (node.Key < y.Key)
      {
         y.Left = node;
      }
      else
      {
         y.Right = node;
      }

      // Fix the tree
      FixInsert(node);
   }

   private void FixInsert(Node k)
   {
      Node uncle;

      // While parent is red
      while (k.Parent != NIL && k.Parent.Color == RED)
      {
         if (k.Parent == k.Parent.Parent.Right)
         {
            uncle = k.Parent.Parent.Left;

            // Case 1: Uncle is red
            if (uncle.Color == RED)
            {
               uncle.Color = BLACK;
               k.Parent.Color = BLACK;
               k.Parent.Parent.Color = RED;
               k = k.Parent.Parent;
            }
            else
            {
               // Case 2: Uncle is black and k is left child
               if (k == k.Parent.Left)
               {
                  k = k.Parent;
                  RightRotate(k);
               }

               // Case 3: Uncle is black and k is right child
               k.Parent.Color = BLACK;
               k.Parent.Parent.Color = RED;
               LeftRotate(k.Parent.Parent);
            }
         }
         else
         {
            uncle = k.Parent.Parent.Right;

            // Case 1: Uncle is red
            if (uncle.Color == RED)
            {
               uncle.Color = BLACK;
               k.Parent.Color = BLACK;
               k.Parent.Parent.Color = RED;
               k = k.Parent.Parent;
            }
            else
            {
               // Case 2: Uncle is black and k is right child
               if (k == k.Parent.Right)
               {
                  k = k.Parent;
                  LeftRotate(k);
               }

               // Case 3: Uncle is black and k is left child
               k.Parent.Color = BLACK;
               k.Parent.Parent.Color = RED;
               RightRotate(k.Parent.Parent);
            }
         }

         if (k == root)
         {
            break;
         }
      }
      root.Color = BLACK;
   }

   private void LeftRotate(Node x)
   {
      Node y = x.Right;
      x.Right = y.Left;

      if (y.Left != NIL)
      {
         y.Left.Parent = x;
      }

      y.Parent = x.Parent;

      if (x.Parent == NIL)
      {
         root = y;
      }
      else if (x == x.Parent.Left)
      {
         x.Parent.Left = y;
      }
      else
      {
         x.Parent.Right = y;
      }

      y.Left = x;
      x.Parent = y;
   }

   private void RightRotate(Node x)
   {
      Node y = x.Left;
      x.Left = y.Right;

      if (y.Right != NIL)
      {
         y.Right.Parent = x;
      }

      y.Parent = x.Parent;

      if (x.Parent == NIL)
      {
         root = y;
      }
      else if (x == x.Parent.Right)
      {
         x.Parent.Right = y;
      }
      else
      {
         x.Parent.Left = y;
      }

      y.Right = x;
      x.Parent = y;
   }

   public Node Search(int key)
   {
      return SearchHelper(root, key);
   }

   private Node SearchHelper(Node node, int key)
   {
      if (node == NIL || key == node.Key)
      {
         return node;
      }

      if (key < node.Key)
      {
         return SearchHelper(node.Left, key);
      }
      return SearchHelper(node.Right, key);
   }

   public void InOrderTraversal()
   {
      Console.WriteLine("In-order traversal of the Red-Black Tree:");
      InOrderHelper(root);
      Console.WriteLine();
   }

   private void InOrderHelper(Node node)
   {
      if (node != NIL)
      {
         InOrderHelper(node.Left);
         Console.Write(node.Key + "(" + (node.Color ? "RED" : "BLACK") + ") ");
         InOrderHelper(node.Right);
      }
   }

   public static void Main(string[] args)
   {
      RedBlackTree rbTree = new RedBlackTree();
      int[] keys = { 7, 3, 18, 10, 22, 8, 11, 26 };

      foreach (int key in keys)
      {
         rbTree.Insert(key);
      }

      rbTree.InOrderTraversal();

      int keyToFind = 10;
      Node foundNode = rbTree.Search(keyToFind);
      if (foundNode != NIL)
      {
         Console.WriteLine("Found key " + keyToFind + ", color: " + (foundNode.Color ? "RED" : "BLACK"));
      }
      else
      {
         Console.WriteLine("Key " + keyToFind + " not found");
      }
   }
}