using System;
using System.Collections.Generic;

class Operation {
   public int ArrivalTime { get; set; }
   public int TargetNode { get; set; }
   public int SourceNode { get; set; }
   public string Key { get; set; }
   public int Value { get; set; }
   public int OpTimestamp { get; set; }

   public Operation(
      int arrivalTime, 
      int targetNode, 
      int sourceNode, 
      string key, 
      int value, 
      int opTimestamp
   ) {
      ArrivalTime = arrivalTime;
      TargetNode = targetNode;
      SourceNode = sourceNode;
      Key = key;
      Value = value;
      OpTimestamp = opTimestamp;
   }
}

public class DistributedCacheConsistency {
   public static List<Dictionary<string, int>> 
   FinalCacheState(
      int n, 
      int[][] operationsData, 
      int[][] delays
   ) {
      var operations = new List<Operation>();
      foreach (var op in operationsData) {
         int nodeId = op[0];
         string key = "key" + op[1];
         int value = op[2];
         int timestamp = op[3];
         operations.Add(
            new Operation(
               0, nodeId, nodeId, key, value, timestamp
            )
         );
      }

      var caches = new List<Dictionary<string, int>>();
      var timestamps = new List<Dictionary<string, int>>();
      for (int i = 0; i < n; i++) {
         caches.Add(new Dictionary<string, int>());
         timestamps.Add(new Dictionary<string, int>());
      }

      var eventQueue = new PriorityQueue<Operation>(
         (op1, op2) => op1.ArrivalTime.CompareTo(op2.ArrivalTime)
      );

      foreach (var op in operations) {
         int nodeId = op.TargetNode;
         eventQueue.Enqueue(op);

         for (int targetNode = 0; targetNode < n; targetNode++) {
            if (targetNode != nodeId) {
               int arrivalTime = op.OpTimestamp + delays[nodeId][targetNode];
               eventQueue.Enqueue(
                  new Operation(
                     arrivalTime, targetNode, nodeId, op.Key, op.Value, op.OpTimestamp
                  )
               );
            }
         }
      }

      while (eventQueue.Count > 0) {
         var op = eventQueue.Dequeue();
         int targetNode = op.TargetNode;
         string key = op.Key;
         int value = op.Value;
         int opTimestamp = op.OpTimestamp;

         if (!timestamps[targetNode].ContainsKey(key) || timestamps[targetNode][key] < opTimestamp) {
            caches[targetNode][key] = value;
            timestamps[targetNode][key] = opTimestamp;
         }
      }

      return caches;
   }

   public static void Main(string[] args) {
      int nodes = 3;
      int[][] operations = {
         new int[] { 0, 0, 10, 1 },
         new int[] { 1, 1, 20, 2 },
         new int[] { 2, 0, 30, 3 },
         new int[] { 0, 1, 40, 4 }
      };
      int[][] delays = {
         new int[] { 0, 2, 3 },
         new int[] { 2, 0, 1 },
         new int[] { 3, 1, 0 }
      };

      var result = FinalCacheState(nodes, operations, delays);

      for (int i = 0; i < result.Count; i++) {
         Console.WriteLine("Node " + i + ": " + string.Join(", ", result[i]));
      }
   }
}