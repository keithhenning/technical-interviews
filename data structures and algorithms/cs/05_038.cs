using System;
using System.Collections.Generic;

public class MainClass
{
   public static void Main(string[] args)
   {
      // Main method code goes here
   }

   public class Graph
   {
      private Dictionary<object, List<object>> graph;

      public Graph()
      {
         this.graph = new Dictionary<object, List<object>>();
      }

      public void Bfs(object start)
      {
         // Keep track of who we've seen
         HashSet<object> visited = new HashSet<object>();
         // People to visit next
         Queue<object> queue = new Queue<object>();
         // Add start node to queue
         queue.Enqueue(start);
         // Mark start as seen
         visited.Add(start);

         while (queue.Count > 0)
         {
            // Get next person to visit
            object vertex = queue.Dequeue();
            // Say hello!
            Console.Write(vertex + " ");

            // Check all their friends
            foreach (object neighbor in this.graph[vertex])
            {
               // If we haven't met them yet
               if (!visited.Contains(neighbor))
               {
                  // Mark them as seen
                  visited.Add(neighbor);
                  // Add to people to visit
                  queue.Enqueue(neighbor);
               }
            }
         }
      }
   }
}
