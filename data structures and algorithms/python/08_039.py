def max_productivity_zone(capacities):

    stack = []
    max_area = 0
    n = len(capacities)
    
    for i in range(n):
        # Process stations with higher capacity than current
        while stack and capacities[stack[-1]] > capacities[i]:
            height = capacities[stack.pop()]
            width = i if not stack else i - stack[-1] - 1
            max_area = max(max_area, height * width)
        
        stack.append(i)
    
    # Process remaining stations in stack
    while stack:
        height = capacities[stack.pop()]
        width = n if not stack else n - stack[-1] - 1
        max_area = max(max_area, height * width)
    
    return max_area