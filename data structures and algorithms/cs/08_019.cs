using System;
using System.Collections.Generic;

public class RateLimiter
{
   private readonly int messageLimit;
   private readonly int timeWindow;
   private readonly Dictionary<string, Queue<int>>
      userMessages;

   public RateLimiter(int messageLimit, int timeWindow)
   {
      this.messageLimit = messageLimit;
      this.timeWindow = timeWindow;
      this.userMessages = new Dictionary<string,
         Queue<int>>();
   }

   public bool CanSend(string userId, int timestamp)
   {
      if (!userMessages.ContainsKey(userId))
      {
         userMessages[userId] = new Queue<int>();
      }

      var messageQueue = userMessages[userId];

      while (messageQueue.Count > 0 &&
         messageQueue.Peek() <= timestamp - timeWindow)
      {
         messageQueue.Dequeue();
      }

      if (messageQueue.Count < messageLimit)
      {
         messageQueue.Enqueue(timestamp);
         return true;
      }

      return false;
   }
}