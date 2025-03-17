import heapq
from collections import deque

class KNearestInWindow:
   def __init__(self, window_size, k):
      self.window_size = window_size
      self.k = k
      self.window = deque()
      # Max heap containing (distance, point) pairs
      self.heap = []
   
   def distance(self, point):
      # Euclidean distance to origin
      return point[0]**2 + point[1]**2
   
   def add_point(self, point):
      dist = self.distance(point)
      
      # Add point to window
      self.window.append((dist, point))
      
      # Remove oldest point if window is too large
      if len(self.window) > self.window_size:
         oldest_dist, oldest_point = self.window.popleft()
         
         # Check if oldest point was in heap
         in_heap = False
         for i, (d, p) in enumerate(self.heap):
            if p == oldest_point:
               in_heap = True
               break
         
         # If oldest point was in heap, rebuild the heap
         if in_heap:
            self.rebuild_heap()
         
      # Add new point to heap if closer than farthest
      # or if heap isn't full yet
      if len(self.heap) < self.k:
         heapq.heappush(self.heap, (-dist, point))
      elif -dist > self.heap[0][0]:
         heapq.heappushpop(self.heap, (-dist, point))
   
   def rebuild_heap(self):
      # Get all points in current window
      points_in_window = [p for _, p in self.window]
      
      # Clear heap and rebuild
      self.heap = []
      for point in points_in_window:
         dist = self.distance(point)
         if len(self.heap) < self.k:
            heapq.heappush(self.heap, (-dist, point))
         elif -dist > self.heap[0][0]:
            heapq.heappushpop(self.heap, (-dist, point))
   
   def get_k_nearest(self):
      # Return the k nearest points
      return [point for _, point in sorted(
         self.heap, key=lambda x: -x[0])]

# Test with example
points = [(1, 2), (3, 4), (0, 1), (5, 2), 
         (2, 0), (1, 5), (3, 1)]
window_size = 5
k = 3

knn = KNearestInWindow(window_size, k)
for point in points:
   knn.add_point(point)

print(knn.get_k_nearest())  # [(2, 0), (0, 1), (3, 1)]