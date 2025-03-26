using System;
using System.Collections.Generic;

public class Node
{
   public int Val { get; set; }
   public Node Left { get; set; }
   public Node Right { get; set; }

   public Node(int val)
   {
      this.Val = val;
      this.Left = null;
      this.Right = null;
   }
}

public class Codec
{
   public string Serialize(Node root)
   {
      if (root == null)
      {
         return "null";
      }
      return $"{root.Val},{Serialize(root.Left)},{Serialize(root.Right)}";
   }

   public Node Deserialize(string data)
   {
      Queue<string> values = new Queue<string>(data.Split(','));
      return DeserializeHelper(values);
   }

   private Node DeserializeHelper(Queue<string> values)
   {
      string val = values.Dequeue();
      if (val == "null")
      {
         return null;
      }
      Node node = new Node(int.Parse(val));
      node.Left = DeserializeHelper(values);
      node.Right = DeserializeHelper(values);
      return node;
   }
}
