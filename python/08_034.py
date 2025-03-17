def trap_rainwater(heights):

    if not heights or len(heights) < 3:
        return 0
    
    left, right = 0, len(heights) - 1
    left_max, right_max = heights[left], heights[right]
    total_water = 0
    
    while left < right:
        if heights[left] < heights[right]:
            left += 1
            if heights[left] < left_max:
                total_water += left_max - heights[left]
            else:
                left_max = heights[left]
        else:
            right -= 1
            if heights[right] < right_max:
                total_water += right_max - heights[right]
            else:
                right_max = heights[right]
                
    return total_water