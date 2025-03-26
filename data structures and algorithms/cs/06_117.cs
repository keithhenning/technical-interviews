using System;
using System.Collections.Generic;
using System.Linq;

public class HuffmanNode : IComparable<HuffmanNode>
{
   public char Character { get; set; }
   public int Frequency { get; set; }
   public HuffmanNode Left { get; set; }
   public HuffmanNode Right { get; set; }

   public int CompareTo(HuffmanNode other)
   {
      return this.Frequency.CompareTo(other.Frequency);
   }
}

public class MinHeap<T> where T : IComparable<T>
{
   private List<T> items = new List<T>();

   public void Enqueue(T item)
   {
      items.Add(item);
      int ci = items.Count - 1;
      while (ci > 0)
      {
         int pi = (ci - 1) / 2;
         if (items[ci].CompareTo(items[pi]) >= 0)
            break;
         T tmp = items[ci];
         items[ci] = items[pi];
         items[pi] = tmp;
         ci = pi;
      }
   }

   public T Dequeue()
   {
      if (items.Count == 0)
         throw new InvalidOperationException();

      T frontItem = items[0];
      items[0] = items[items.Count - 1];
      items.RemoveAt(items.Count - 1);

      if (items.Count > 0)
      {
         int pi = 0;
         while (true)
         {
            int ci = pi * 2 + 1;
            if (ci >= items.Count)
               break;

            if (ci + 1 < items.Count &&
               items[ci + 1].CompareTo(items[ci]) < 0)
               ci++;

            if (items[pi].CompareTo(items[ci]) <= 0)
               break;

            T tmp = items[pi];
            items[pi] = items[ci];
            items[ci] = tmp;
            pi = ci;
         }
      }
      return frontItem;
   }

   public int Count => items.Count;

   public T Peek() =>
      items.Count > 0
         ? items[0]
         : throw new InvalidOperationException();
}

public class HuffmanCoding
{
   public static Dictionary<char, string> BuildHuffmanTree(
      string text)
   {
      // Count frequencies
      var frequency = new Dictionary<char, int>();
      foreach (char c in text)
      {
         if (!frequency.ContainsKey(c))
            frequency[c] = 0;
         frequency[c]++;
      }

      // Create priority queue
      var queue = new MinHeap<HuffmanNode>();
      foreach (var pair in frequency)
      {
         queue.Enqueue(new HuffmanNode
         {
            Character = pair.Key,
            Frequency = pair.Value
         });
      }

      // Build tree
      while (queue.Count > 1)
      {
         var x = queue.Dequeue();
         var y = queue.Dequeue();

         var sum = new HuffmanNode
         {
            Frequency = x.Frequency + y.Frequency,
            Left = x,
            Right = y
         };

         queue.Enqueue(sum);
      }

      // Generate codes
      var codes = new Dictionary<char, string>();
      GenerateCodes(queue.Peek(), "", codes);
      return codes;
   }

   private static void GenerateCodes(
      HuffmanNode node,
      string code,
      Dictionary<char, string> codes)
   {
      if (node == null)
         return;

      if (node.Left == null && node.Right == null)
      {
         codes[node.Character] = code;
         return;
      }

      GenerateCodes(node.Left, code + "0", codes);
      GenerateCodes(node.Right, code + "1", codes);
   }
}
