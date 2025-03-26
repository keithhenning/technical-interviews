public static int MaxArea(int[] height)
{
   int left = 0;
   int right = height.Length - 1;
   int maxArea = 0;

   while (left < right)
   {
      // Calculate width between pointers
      int width = right - left;
      // Calculate area using the smaller height
      maxArea = Math.Max(maxArea,
                  width * Math.Min(
                     height[left],
                     height[right]
                     )
                  );

      // Move the pointer with smaller height
      if (height[left] < height[right])
      {
         left++;
      }
      else
      {
         right--;
      }
   }

   return maxArea;
}