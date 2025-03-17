def maxHolidayJoy(joyRatings, minCards, maxCards):
  n = len(joyRatings)
  if n < minCards:
     return 0
  
  # Calculate sum of initial minimum window
  current_sum = sum(joyRatings[:minCards])
  max_joy = current_sum
  
  # Try each valid window size from minCards to maxCards
  for window_size in range(minCards, min(maxCards + 1, n + 1)):
     # If increasing window size from previous iteration
     if window_size > minCards:
        current_sum += joyRatings[window_size - 1]
     
     # Initial window of current size
     temp_max = current_sum
     
     # Slide the window across the array
     for i in range(window_size, n):
        current_sum += joyRatings[i] - joyRatings[i - window_size]
        temp_max = max(temp_max, current_sum)
     
     max_joy = max(max_joy, temp_max)
     
     # Reset current_sum for next window size
     current_sum = sum(joyRatings[:window_size])
  
  return max_joy