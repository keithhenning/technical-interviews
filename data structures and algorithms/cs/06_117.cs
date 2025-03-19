using System;
using System.Collections.Generic;

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

public class HuffmanCoding
{
    public static Dictionary<char, string> BuildHuffmanTree(string text)
    {
        // Count frequencies
        Dictionary<char, int> frequency = new Dictionary<char, int>();
        foreach (char c in text)
        {
            if (!frequency.ContainsKey(c))
                frequency[c] = 0;
            frequency[c]++;
        }

        // Create priority queue
        var queue = new PriorityQueue<HuffmanNode, int>();
        foreach (var pair in frequency)
        {
            queue.Enqueue(new HuffmanNode 
            { 
                Character = pair.Key, 
                Frequency = pair.Value 
            }, pair.Value);
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
            
            queue.Enqueue(sum, sum.Frequency);
        }

        // Generate codes
        var codes = new Dictionary<char, string>();
        GenerateCodes(queue.Peek(), "", codes);
        return codes;
    }

    private static void GenerateCodes(HuffmanNode node, string code, 
        Dictionary<char, string> codes)
    {
        if (node == null) return;
        
        if (node.Left == null && node.Right == null)
        {
            codes[node.Character] = code;
            return;
        }

        GenerateCodes(node.Left, code + "0", codes);
        GenerateCodes(node.Right, code + "1", codes);
    }
}
