/**
 * Dutch national flag algorithm for sorting colors
 */
class Solution
{
   /**
    * Sort array containing only 0s, 1s, and 2s
    */
   public void sortColors(int[] nums)
   {
      int low = 0;
      int curr = 0;
      int high = nums.length - 1;

      while (curr <= high)
      {
         if (nums[curr] == 0)
         {
            // Move 0 to the left section
            int temp = nums[low];
            nums[low] = nums[curr];
            nums[curr] = temp;
            low++;
            curr++;
         }
         else if (nums[curr] == 2)
         {
            // Move 2 to the right section
            // Don't increment curr as swapped element needs checking
            int temp = nums[high];
            nums[high] = nums[curr];
            nums[curr] = temp;
            high--;
         }
         else
         {
            // Element is 1, keep in middle section
            curr++;
         }
      }
   }
}