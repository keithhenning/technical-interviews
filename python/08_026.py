import heapq

def final_cache_state(n, operations, delays):
   # Initialize caches for each node
   caches = [{} for _ in range(n)]
   
   # Priority queue to simulate events with timestamps
   event_queue = []
   
   # Add initial operations to queue
   for node_id, key, value, timestamp in operations:
      # Process operation at source node immediately
      heapq.heappush(event_queue, 
                    (timestamp, node_id, node_id, key, 
                     value, timestamp))
      
      # Schedule propagation to other nodes
      for target_node in range(n):
         if target_node != node_id:
            arrival_time = timestamp + delays[node_id][target_node]
            heapq.heappush(event_queue, 
                          (arrival_time, target_node, node_id, key, 
                           value, timestamp))
   
   # Process all events
   while event_queue:
      arrival_time, target_node, source_node, key, value, op_timestamp = heapq.heappop(event_queue)
      
      # Apply the operation if it's newer than what we have
      if (key not in caches[target_node] or 
          caches[target_node].get(key + "_timestamp", 0) < op_timestamp):
         caches[target_node][key] = value
         caches[target_node][key + "_timestamp"] = op_timestamp
   
   # Clean up internal timestamp tracking
   for cache in caches:
      for key in list(cache.keys()):
         if key.endswith("_timestamp"):
            del cache[key]
   
   return caches

# Test with example
nodes = 3
operations = [
   (0, "x", 10, 1),  # Node 0 sets x=10 at time 1
   (1, "y", 20, 2),  # Node 1 sets y=20 at time 2
   (2, "x", 30, 3),  # Node 2 sets x=30 at time 3
   (0, "y", 40, 4)   # Node 0 sets y=40 at time 4
]
delays = [
   [0, 2, 3],  # Delays from node 0 to others
   [2, 0, 1],  # Delays from node 1 to others
   [3, 1, 0]   # Delays from node 2 to others
]

print(final_cache_state(nodes, operations, delays))