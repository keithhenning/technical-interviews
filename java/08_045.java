/**
* Solution for finding minimum processing power needed
*/
class Solution {
  /**
   * Find minimum processing power needed to complete tasks
   */
  public int minProcessingPower(int[] tasks, int maxSeconds) {
     // Find maximum task demand
     int maxTask = 0;
     for (int task : tasks) {
        maxTask = Math.max(maxTask, task);
     }
     
     // Binary search for minimum sufficient power
     int left = 1;
     int right = maxTask;
     
     while (left < right) {
        int mid = left + (right - left) / 2;
        if (canComplete(tasks, mid, maxSeconds)) {
           right = mid;
        } else {
           left = mid + 1;
        }
     }
     
     return left;
  }
  
  /**
   * Check if tasks can be completed with given power
   */
  private boolean canComplete(int[] tasks, int power, 
        int maxSeconds) {
     int totalTime = 0;
     for (int task : tasks) {
        // Ceiling division for time required
        totalTime += (task + power - 1) / power;
     }
     return totalTime <= maxSeconds;
  }
}