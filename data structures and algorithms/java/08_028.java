import java.util.*;

/**
 * Represents a 2D point
 */
class Point {
   int x, y;
   
   public Point(int x, int y) {
      this.x = x;
      this.y = y;
   }
   
   public int distanceToOrigin() {
      return x*x + y*y;
   }
   
   @Override
   public boolean equals(Object obj) {
      if (this == obj) return true;
      if (!(obj instanceof Point)) return false;
      Point other = (Point) obj;
      return x == other.x && y == other.y;
   }
   
   @Override
   public int hashCode() {
      return Objects.hash(x, y);
   }
   
   @Override
   public String toString() {
      return "(" + x + ", " + y + ")";
   }
}

/**
 * Tracks k nearest points within a sliding window
 */
class KNearestInWindow {
   private final int windowSize;
   private final int k;
   private final Deque<Point> window;
   private final PriorityQueue<Point> heap; 
   
   /**
    * Initialize with window size and k
    */
   public KNearestInWindow(int windowSize, int k) {
      this.windowSize = windowSize;
      this.k = k;
      this.window = new LinkedList<>();
      // Max heap (farthest first)
      this.heap = new PriorityQueue<>(
         (p1, p2) -> p2.distanceToOrigin() - 
                     p1.distanceToOrigin());
   }
   
   /**
    * Add a point to the sliding window
    */
   public void addPoint(Point point) {
      // Add point to window
      window.addLast(point);
      
      // Remove oldest point if window is full
      if (window.size() > windowSize) {
         Point oldest = window.removeFirst();
         
         // Rebuild heap if oldest point was in heap
         if (heap.contains(oldest)) {
            rebuildHeap();
         }
      }
      
      // Update heap with new point if it's close enough
      if (heap.size() < k) {
         heap.offer(point);
      } else if (point.distanceToOrigin() < 
                 heap.peek().distanceToOrigin()) {
         heap.poll();
         heap.offer(point);
      }
   }
   
   /**
    * Rebuild heap when window changes
    */
   private void rebuildHeap() {
      // Clear heap
      heap.clear();
      
      // Create a list of current window points
      List<Point> points = new ArrayList<>(window);
      
      // Sort by distance
      points.sort(Comparator.comparingInt(
         Point::distanceToOrigin));
      
      // Add k closest points to heap
      for (int i = 0; i < Math.min(k, points.size()); i++) {
         heap.offer(points.get(i));
      }
   }
   
   /**
    * Get k nearest points in current window
    */
   public List<Point> getKNearest() {
      // Convert heap to sorted list
      List<Point> result = new ArrayList<>(heap);
      result.sort(Comparator.comparingInt(
         Point::distanceToOrigin));
      return result;
   }
   
   /**
    * Test the implementation
    */
   public static void main(String[] args) {
      // Test with example points
      int[][] pointsArray = {
         {1, 2}, {3, 4}, {0, 1}, {5, 2}, 
         {2, 0}, {1, 5}, {3, 1}
      };
      int windowSize = 5;
      int k = 3;
      
      KNearestInWindow knn = new KNearestInWindow(windowSize, k);
      for (int[] p : pointsArray) {
         knn.addPoint(new Point(p[0], p[1]));
      }
      
      List<Point> result = knn.getKNearest();
      System.out.println("K nearest points: " + result);
   }
}