import heapq

from dataclasses import dataclass
from typing import List, Tuple

@dataclass
class Request:
   id: int
   size: int

@dataclass
class Server:
   id: int
   capacity: int
   current_load: int = 0
   last_active: int = 0

def assign_requests(requests: List[Request], 
                  servers: List[Server]) -> List[Tuple[int, int]]:
   server_heap = [(0, 0, server.id) for server in servers]
   heapq.heapify(server_heap)
   
   server_map = {server.id: server for server in servers}
   
   assignments = []
   current_time = 0
   
   for request in requests:
      current_time += 1
      
      if not server_heap:
         break
         
      load, last_active, server_id = heapq.heappop(
         server_heap)
      server = server_map[server_id]
      
      if server.current_load + request.size <= server.capacity:
         server.current_load += request.size
         server.last_active = current_time
         assignments.append((server_id, request.id))
         
         heapq.heappush(server_heap, 
                     (server.current_load, -current_time, 
                     server_id))
   
   return assignments