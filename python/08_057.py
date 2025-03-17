def min_max_group_sum(nums, k):

    def can_split(threshold):
        groups = 1
        current_sum = 0
        
        for num in nums:
            # If a single element exceeds threshold, 
            # splitting is impossible
            if num > threshold:
                return False
            
            # Try adding the current number to the current group
            if current_sum + num <= threshold:
                current_sum += num
            else:
                # Start a new group
                groups += 1
                current_sum = num
                
                # If we need more than k groups, return False
                if groups > k:
                    return False
                    
        return True
    
    # Binary search on the possible threshold values
    left = max(nums)
    right = sum(nums)
    
    while left < right:
        mid = (left + right) // 2
        if can_split(mid):
            right = mid
        else:
            left = mid + 1
            
    return left