using System;

public class BinaryNode
{
   public object Value { get; set; }
   public BinaryNode Left { get; set; }
   public BinaryNode Right { get; set; }

   public BinaryNode(object value)
   {
      this.Value = value;
      this.Left = null;
      this.Right = null;
   }
}
