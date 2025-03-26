using System;

class PlayerNode
{
   public string Name { get; }
   public double BattingAverage { get; }
   public PlayerNode Next { get; set; }

   public PlayerNode(
      string name,
      double battingAverage)
   {
      Name = name;
      BattingAverage = battingAverage;
      Next = null;
   }
}

public class Solution
{
   public string RotateLineupAndFindBest(
      PlayerNode head,
      int k,
      int m)
   {
      if (head == null || head.Next == head || k == 0)
      {
         return FindBestBatter(head, m);
      }

      PlayerNode current = head;
      for (int i = 0; i < k - 1; i++)
      {
         current = current.Next;
      }

      PlayerNode newHead = current.Next;

      PlayerNode last = newHead;
      while (last.Next != head)
      {
         last = last.Next;
      }

      current.Next = head;
      last.Next = newHead;

      return FindBestBatter(newHead, m);
   }

   private string FindBestBatter(
      PlayerNode head,
      int m)
   {
      if (head == null)
      {
         return null;
      }

      PlayerNode bestPlayer = head;
      PlayerNode current = head;

      for (int i = 0; i < m - 1; i++)
      {
         current = current.Next;
         if (current.BattingAverage >
            bestPlayer.BattingAverage)
         {
            bestPlayer = current;
         }

         if (current == head)
         {
            break;
         }
      }

      return bestPlayer.Name;
   }
}
