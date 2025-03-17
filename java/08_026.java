import java.util.*;

/**
 * Represents a cache operation with timing information
 */
class Operation {
   int arrivalTime;
   int targetNode;
   int sourceNode;
   String key;
   int value;
   int opTimestamp;
   
   Operation(int arrivalTime, int targetNode, int sourceNode, 
         String key, int value, int opTimestamp) {
      this.arrivalTime = arrivalTime;
      this.targetNode = targetNode;
      this.sourceNode = sourceNode;
      this.key = key;
      this.value = value;
      this.opTimestamp = opTimestamp;
   }
}

/**
 * Simulates eventual consistency in a distributed cache
 */
public class DistributedCacheConsistency {
   /**
    * Compute final cache state after operations propagate
    */
   public static List<Map<String, Integer>> finalCacheState(
         int n, int[][] operationsData, int[][] delays) {
      // Convert raw data to operation objects
      List<Operation> operations = new ArrayList<>();
      for (int[] op : operationsData) {
         int nodeId = op[0];
         String key = "key" + op[1]; // Convert to string key
         int value = op[2];
         int timestamp = op[3];
         operations.add(new Operation(0, nodeId, nodeId, key, 
               value, timestamp));
      }
      
      // Initialize node caches and timestamp tracking
      List<Map<String, Integer>> caches = new ArrayList<>();
      List<Map<String, Integer>> timestamps = new ArrayList<>();
      for (int i = 0; i < n; i++) {
         caches.add(new HashMap<>());
         timestamps.add(new HashMap<>());
      }
      
      // Event queue ordered by arrival time
      PriorityQueue<Operation> eventQueue = 
            new PriorityQueue<>(
               Comparator.comparingInt(op -> op.arrivalTime)
            );
      
      // Schedule initial operations and their propagation
      for (Operation op : operations) {
         int nodeId = op.targetNode;
         
         // Add local operation
         eventQueue.add(op);
         
         // Schedule propagation to other nodes with delays
         for (int targetNode = 0; targetNode < n; targetNode++) {
            if (targetNode != nodeId) {
               int arrivalTime = op.opTimestamp + 
                     delays[nodeId][targetNode];
               eventQueue.add(new Operation(
                     arrivalTime, 
                     targetNode, 
                     nodeId, 
                     op.key, 
                     op.value, 
                     op.opTimestamp));
            }
         }
      }
      
      // Process all operations in time order
      while (!eventQueue.isEmpty()) {
         Operation op = eventQueue.poll();
         int targetNode = op.targetNode;
         String key = op.key;
         int value = op.value;
         int opTimestamp = op.opTimestamp;
         
         // Apply operation if newer (last write wins)
         Integer currentTimestamp = 
               timestamps.get(targetNode).get(key);
         if (currentTimestamp == null || 
               currentTimestamp < opTimestamp) {
            caches.get(targetNode).put(key, value);
            timestamps.get(targetNode).put(key, opTimestamp);
         }
      }
      
      return caches;
   }
   
   /**
    * Test the distributed cache simulator
    */
   public static void main(String[] args) {
      int nodes = 3;
      int[][] operations = {
         {0, 0, 10, 1},  // Node 0 sets key0=10 at time 1
         {1, 1, 20, 2},  // Node 1 sets key1=20 at time 2
         {2, 0, 30, 3},  // Node 2 sets key0=30 at time 3
         {0, 1, 40, 4}   // Node 0 sets key1=40 at time 4
      };
      int[][] delays = {
         {0, 2, 3},  // Delays from node 0 to others
         {2, 0, 1},  // Delays from node 1 to others
         {3, 1, 0}   // Delays from node 2 to others
      };
      
      List<Map<String, Integer>> result = 
         finalCacheState(nodes, operations, delays);
      
      // Print final state of each node's cache
      for (int i = 0; i < result.size(); i++) {
         System.out.println("Node " + i + ": " + result.get(i));
      }
   }
}