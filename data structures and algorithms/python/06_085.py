def largest_rectangle_area(heights):
  stack = []
  max_area = 0
  i = 0
  
  while i < len(heights):
     # Push if stack empty or height increasing
     if not stack or heights[stack[-1]] <= heights[i]:
        stack.append(i)
        i += 1
     else:
        # Calculate area with stack top as smallest bar
        top = stack.pop()
        
        # Calculate width
        width = i if not stack else i - stack[-1] - 1
        
        # Update max area
        max_area = max(max_area, heights[top] * width)
  
  # Process remaining stack elements
  while stack:
     top = stack.pop()
     width = i if not stack else i - stack[-1] - 1
     max_area = max(max_area, heights[top] * width)
  
  return max_area

# Example usage
heights = [2, 1, 5, 6, 2, 3]
print(largest_rectangle_area(heights))