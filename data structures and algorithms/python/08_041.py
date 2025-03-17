def min_processing_speed(batches, h):

    def can_complete(speed):
        hours = 0
        for batch in batches:
            # Ceiling division to calculate hours needed
            hours += (batch + speed - 1) // speed
        return hours <= h
    
    left, right = 1, max(batches)
    
    while left < right:
        mid = left + (right - left) // 2
        if can_complete(mid):
            right = mid
        else:
            left = mid + 1
            
    return left