using System;
using System.Collections.Generic;

public class MainClass
{
    public static void Main(string[] args)
    {
        // Main method code goes here
    }

    public Node FindMiddle(Node head)
    {
        Node slow = head;
        Node fast = head;
        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }
        return slow;
    }
}

public class Node
{
    public object Data { get; set; }
    public Node Next { get; set; }

    public Node(object data)
    {
        Data = data;
        Next = null;
    }
}
